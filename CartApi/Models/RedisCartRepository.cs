using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CartApi.Models
{
    public class RedisCartRepository : ICartRepository
    {
        // Module 21 adding cart and Redis cache - Time 18 Minutes
        private readonly ConnectionMultiplexer _redis;
        private readonly IDatabase _database;

        // Constructor to inject the redis storage - connection multiplexer -redist, georeplication
        public RedisCartRepository(ConnectionMultiplexer redis)
        {
            _redis = redis;  // high level storage
            _database = _redis.GetDatabase(); // the database inside the redis storage
        }
        public async Task<Cart> GetCartAsync(string cartId)
        {
            // cartId is the buyerId - find the cache with this cartID and store in data - key value pair
            var data = await _database.StringGetAsync(cartId);
            if (data.IsNullOrEmpty)
            {
                return null;
            }
            //if we have data then the cart has buyer id and list of cart items, needs to deserialize
            return JsonConvert.DeserializeObject<Cart>(data);
        }

        public IEnumerable<string> GetUsers()
        {
            var server = GetServer();
            var data = server.Keys();
            // return data == null ? null : data.Select(k => k.ToString()); -- shorter form of ternary operator
            return data?.Select(k => k.ToString());
        }

        private IServer GetServer()
        {
            var endpoint = _redis.GetEndPoints();
            return _redis.GetServer(endpoint.First());  // nearest redis server and gives the first one located
        }

        // we are writing to redis cache in a serialized string, with buyerID and the entire basket
        public async Task<Cart> UpdateCartAsync(Cart basket)
        {
            var created = await _database.StringSetAsync(basket.BuyerId, JsonConvert.SerializeObject(basket));

            if (!created)
            {
                return null;
            }

            return await GetCartAsync(basket.BuyerId);
        }
        public async Task<bool> DeleteCartAsync(string id)
        {
            return await _database.KeyDeleteAsync(id);  //just delete the key where the buyer id is stored in redis
        }
    }
}
