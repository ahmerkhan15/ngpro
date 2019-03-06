using System;

namespace GamingStore.API.DTO
{
    public class AddToCartDTO
    {
        public string prodID { get; set; }
        public decimal quantity { get; set; }
        public decimal price { get; set; }
        public string sessionID { get; set; }
        public string cstID { get; set; }
    }
}
