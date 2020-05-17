using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CartApi.Models
{
    public class Cart
    {
        // Module 21 - Adding CartItem and Cart
        public List<CartItem> Items { get; set; }
        public string BuyerId { get; set; }

        public Cart()
        { }
        // Constructor for a first time buyer adding to cart, where they try to add a new item
        //cartID is the same as buyerID which is the email address
        public Cart(string cartId)
        {
            BuyerId = cartId;
            Items = new List<CartItem>();
        }
    }
}
