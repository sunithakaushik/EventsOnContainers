using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CartApi.Models
{
    public class CartItem
    {
        // Module 21 - Adding CartItem and Cart
        public string Id { get; set; }
        public string EventId { get; set; }
        public string EventTitle { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal OldUnitPrice { get; set; }
        public int Quantity { get; set; }
        public string PictureUrl { get; set; }
    }
}
