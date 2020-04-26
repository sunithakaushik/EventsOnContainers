using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMvc.Infrastructure;
using WebMvc.Models;

namespace WebMvc.Services
{
    public class CatalogService : ICatalogService
    {
        private readonly string _baseUri;
        private readonly IHttpClient _client;
        
        public CatalogService(IConfiguration config, IHttpClient client)
        {
            _baseUri = $"{config["CatalogUrl"]}/api/event/";
            _client = client;
        }
        public async Task<EventCatalog> GetCatalogEventAsync(int page, int size, int? type, int? topic)
        {
            var catalogItemsUri = ApiPaths.Catalog.GetAllCatalogEvents(_baseUri, page, size, type, topic);
            var dataString = await _client.GetStringAsync(catalogItemsUri);

            return JsonConvert.DeserializeObject<EventCatalog>(dataString);
        }

        public async Task<IEnumerable<SelectListItem>> GetTopicsAsync()
        {
            var topicUri = ApiPaths.Catalog.GetAllTopics(_baseUri);
            var dataString = await _client.GetStringAsync(topicUri);
            var items = new List<SelectListItem>
            {
                new SelectListItem
                {
                    // Built in asp.net properties for selectlistitem
                    Value = null,
                    Text = "All",
                    Selected = true
                }
            };
            var topics = JArray.Parse(dataString);
            foreach (var topic in topics)
            {
                items.Add(
                    new SelectListItem
                    {
                        // Based on the json object that is being returned from the db schema 
                        Value = topic.Value<string>("id"),
                        Text = topic.Value<string>("topic")
                    });
            }
            return items;
        }

        public async Task<IEnumerable<SelectListItem>> GetTypesAsync()
        {
            var typeUri = ApiPaths.Catalog.GetAllTypes(_baseUri);
            var dataString = await _client.GetStringAsync(typeUri);
            var items = new List<SelectListItem>
            {
                new SelectListItem
                {
                    // Built in asp.net properties for selectlistitem
                    Value = null,
                    Text = "All",
                    Selected = true
                }
            };
            var types = JArray.Parse(dataString);
            foreach (var type in types)
            {
                items.Add(
                    new SelectListItem
                    {
                        // Based on the json object that is being returned from the db schema 
                        Value = type.Value<string>("id"),
                        Text = type.Value<string>("type")
                    });
            }
            return items;
        }
    }
}
