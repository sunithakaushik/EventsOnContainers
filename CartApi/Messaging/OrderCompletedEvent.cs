using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


//Note the namespace is common, Module 26, this is how the message gets delv. 
// type has to be the same, publish the same type and subscribe to be the same type
namespace Common.Messaging
{
    public class OrderCompletedEvent
    {
        public string BuyerId { get; set; }
        public OrderCompletedEvent(string buyerId)
        {
            BuyerId = buyerId;
        }
    }
}