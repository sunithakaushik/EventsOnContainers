using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CartApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using StackExchange.Redis;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.OpenApi.Models;
using System.IdentityModel.Tokens.Jwt;
using Autofac;
using MassTransit;
using CartApi.Messaging.Consumers;
using Autofac.Extensions.DependencyInjection;
using MassTransit.Util;
using RabbitMQ.Client;

namespace CartApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // needed for post to work, from webmvc as it is coming in the form of a json file
            // Module 25 - 20 minutes to install the Microsoft newton soft package
            services.AddControllers().AddNewtonsoftJson();
            services.AddTransient<ICartRepository, RedisCartRepository>();

            // transient allows multiple instances of the repository, where as having 
            //singleton, allows only 1 instance of the redis // module 21 - 1:00:30
            services.AddSingleton<ConnectionMultiplexer>(cm =>
            {
                // store this in a variable so that we can catch failures in case it does not setup
                var configuration = ConfigurationOptions.Parse(Configuration["ConnectionString"], true);
                configuration.ResolveDns = true; // needs to point to a machine with a IP address
                configuration.AbortOnConnectFail = false; // if not able to connect do not abort, will do retry
                return ConnectionMultiplexer.Connect(configuration);
            });
            ConfigureAuthService(services);
            services.AddSwaggerGen(options =>
            {
                //options.DescribeAllEnumsAsStrings();
                options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "EventsOnContatiners -  Basket API",
                    Version = "v1",
                    Description = "Basket service API",
                    // TermsOfService = new Uri ("Terms Of Service")
                });
                // Adding auth to swagger, should not expose data of the cart in swagger
                options.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
                options.AddSecurityDefinition("oauth", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.OAuth2,
                    Flows = new OpenApiOAuthFlows
                    {
                        //just confirming implicitly the cartapi behind the scene to the IDentity (mod22 -42 mins)
                        Implicit = new OpenApiOAuthFlow 
                        {
                            AuthorizationUrl = new Uri($"{Configuration["IdentityUrl"]}/connect/authorize"),
                            TokenUrl = new Uri($"{Configuration["IdentityUrl"]}/connect/token"),
                            Scopes = new Dictionary<string, string>
                            {
                                {"basket", "Basket Api" }
                            }
                        }
                    }
                });
            });

            // same as order, but here it is a consumer, when a mesg is recvd, we are calling a diff class  
            // Recvg. end point hass the queue name (Module 26- 36 mins) can have another one here
            services.AddMassTransit(cfg =>
            {
                cfg.AddConsumer<OrderCompletedEventConsumer>();
                cfg.AddBus(provider =>
                {
                    return Bus.Factory.CreateUsingRabbitMq(rmq =>
                    {
                        rmq.Host(new Uri("rabbitmq://rabbitmq"), "/", h =>
                        {
                            h.Username("guest");
                            h.Password("guest");
                        });
                        rmq.ReceiveEndpoint("EventsCartMay10", e =>
                        {
                            e.ConfigureConsumer<OrderCompletedEventConsumer>(provider);

                        });
                    });

                });
            });

            services.AddMassTransitHostedService();

        }
        private void ConfigureAuthService(IServiceCollection services)
        {
            // Module 22 - integrate the identity server - ip address
            var identityUrl = Configuration["IdentityUrl"];
            // Adding authentication to the services
            services.AddAuthentication(options =>
            {
                // json web token - used for authentication - we decode this to find out permissions
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.Authority = identityUrl;  // the identity url is the one issuing the token
                options.RequireHttpsMetadata = false;
                options.Audience = "basket";  // from config.cs in tokenservice api, this is one of the token  (Module22, 28min)
            });
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseAuthentication(); // only this will ensure authentication happens

            app.UseAuthorization();
            app.UseSwagger().UseSwaggerUI(e =>
            {
                e.SwaggerEndpoint($"/swagger/v1/swagger.json", "BasketAPI V1");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
