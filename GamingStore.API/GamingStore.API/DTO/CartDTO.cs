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
        public Products product { get; set; }
    }
}
