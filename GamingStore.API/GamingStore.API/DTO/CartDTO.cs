using GamingStore.API.Models;
using System;
using System.Collections.Generic;

namespace GamingStore.API.DTO
{
    public class CartDTO
    {
        public string orderID { get; set; }
        public string customerID { get; set; }
        public DateTime date { get; set; }
        public decimal total { get; set; }
        public List<CartItemDTO> cartItem { get; set; }
    }

    public class CartItemDTO
    {
        public string prodID { get; set; }
        public decimal quantity { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public decimal price { get; set; }
        public string genre { get; set; }
        public string image { get; set; }
    }

    public class CartRemoveDTO
    {
        public string OrderId { get; set; }
        public string ProductId { get; set; }
    }
}
