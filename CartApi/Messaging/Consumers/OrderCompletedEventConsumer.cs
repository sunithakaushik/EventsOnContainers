using CartApi.Models;
using Common.Messaging;
using MassTransit;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CartApi.Messaging.Consumers
{
    // a special class of type IConsumer of MassTransit when a order completed event mesg comes
    // if needed can created another for the price change event
    public class OrderCompletedEventConsumer : IConsumer<OrderCompletedEvent>
    {
        private readonly ICartRepository _repository;
        private readonly ILogger<OrderCompletedEventConsumer> _logger;
        public OrderCompletedEventConsumer(ICartRepository repository, ILogger<OrderCompletedEventConsumer> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        // listener, when recv message this automatically calls - allways up and running
        // we do not call from anywhere, 
        public async Task Consume(ConsumeContext<OrderCompletedEvent> context)
        {
            _logger.LogWarning("We are in consume method now...");
            _logger.LogWarning("BuyerId:" + context.Message.BuyerId);
            await _repository.DeleteCartAsync(context.Message.BuyerId);
            // Deletes the cart - in the redis cache, for this buyer id , delete all the cache
        }
    }
}