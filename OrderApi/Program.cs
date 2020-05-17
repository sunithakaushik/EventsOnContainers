using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using OrderApi.Data;

namespace OrderApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // as there is no guarantee that the sql server has started yet, we need 
            // still the sql container is being built before we do the migration
            // to call the Migrate Database in the program.cs before the startup.cs is called
            CreateHostBuilder(args).Build();
            var host = CreateHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope())
            {
                var serviceProviders = scope.ServiceProvider;
                var context = serviceProviders.GetRequiredService<OrdersContext>();
                MigrateDatabase.EnsureCreated(context);
            }
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
