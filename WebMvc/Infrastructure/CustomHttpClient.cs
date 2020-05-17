using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace WebMvc.Infrastructure
{
    public class CustomHttpClient : IHttpClient
    {
        private readonly HttpClient _client;
        public CustomHttpClient()
        {
            _client = new HttpClient();
        }        

        public async Task<string> GetStringAsync(string uri, string authorizationToken = null, string authorizationMethod = "Bearer")
        {
            // Step 6 in Module 16 http client making a request to Microservice
            var requestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
            if (authorizationToken != null) // only if someone has logged in to the site, then the token is there
            {
                 requestMessage.Headers.Authorization = new AuthenticationHeaderValue(authorizationMethod, authorizationToken);
            }
            //step 7 in module 16 http client receives the response message from Microservice
            var response = await _client.SendAsync(requestMessage);
            // getting the response as a string and interested in only the content in response mesg.
            return await response.Content.ReadAsStringAsync();
        }

        private async Task<HttpResponseMessage> DoPostPutAsync<T>(HttpMethod method, string uri, T item,
           string authorizationToken = null, string authorizationMethod = "Bearer")
        {
            if (method != HttpMethod.Post && method != HttpMethod.Put)
            {
                throw new ArgumentException("Value must be either post or put.", nameof(method));
            }

            var requestMessage = new HttpRequestMessage(method, uri);
            Console.WriteLine(JsonConvert.SerializeObject(item));
            requestMessage.Content = new StringContent(JsonConvert.SerializeObject(item), System.Text.Encoding.UTF8, "application/json");
            if (authorizationToken != null)
            {
                requestMessage.Headers.Authorization = new AuthenticationHeaderValue(authorizationMethod, authorizationToken);
            }

            var response = await _client.SendAsync(requestMessage);

            if (response.StatusCode == HttpStatusCode.InternalServerError)
            {
                throw new HttpRequestException();
            }

            return response;
        }

        public async Task<HttpResponseMessage> PostAsync<T>(string uri, T item,
            string authorizationToken = null, string authorizationMethod = "Bearer")
        {
            return await DoPostPutAsync(HttpMethod.Post, uri, item, authorizationToken, authorizationMethod);
        }

        public async Task<HttpResponseMessage> PutAsync<T>(string uri, T item,
            string authorizationToken = null, string authorizationMethod = "Bearer")
        {
            return await DoPostPutAsync(HttpMethod.Put, uri, item, authorizationToken, authorizationMethod);
        }
        public async Task<HttpResponseMessage> DeleteAsync(string uri, string authorizationToken = null,
            string authorizationMethod = "Bearer")
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);
            if (authorizationToken != null)
            {
                requestMessage.Headers.Authorization = new AuthenticationHeaderValue(authorizationMethod, authorizationToken);
            }
            return await _client.SendAsync(requestMessage);
        }
    }
}

