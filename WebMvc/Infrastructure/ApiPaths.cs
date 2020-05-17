using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMvc.Infrastructure
{
    public class ApiPaths
    {
        public static class Catalog
        {
            public static string GetAllCatalogEvents(string baseUri, int page, int take, int? topic, int? type)
            {
                var filterQs = string.Empty;
                if (topic.HasValue || type.HasValue)
                {
                    var topicQs = (topic.HasValue) ? topic.Value.ToString() : string.Empty;
                    var typeQs = (type.HasValue) ? type.Value.ToString() : string.Empty;
                    filterQs = $"/type/{typeQs}/topic/{topicQs}";
                }
                return $"{baseUri}events{filterQs}?pageIndex={page}&pageSize={take}";
            }
            public static string GetAllTypes(string baseUri)
            {
                return $"{baseUri}eventtypes";
            }

            public static string GetAllTopics(string baseUri)
            {
                return $"{baseUri}eventtopics";
            }
        }

        //  Module 23 - Integrating Cart to webmvc
        public static class Basket
        {
            public static string GetBasket(string baseUri, string basketId)
            {
                return $"{baseUri}/{basketId}";
            }
            public static string UpdateBasket(string baseUri)
            {
                return baseUri;
            }
            public static string CleanBasket(string baseUri, string basketId)
            {
                return $"{baseUri}/{basketId}";
            }
        }

        // Module 25 - 25 minutes
        public static class Order
        {
            public static string GetOrder(string baseUri, string orderId)
            {
                return $"{baseUri}/{orderId}";
            }
            //public static string GetOrdersByUser(string baseUri, string userName)
            //{
            //    return $"{baseUri}/userOrders?userName={userName}";
            //}
            public static string GetOrders(string baseUri)
            {
                return baseUri;
            }
            public static string AddNewOrder(string baseUri)
            {
                return $"{baseUri}/new";
            }
        }
    }
}
