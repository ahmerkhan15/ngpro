using GamingStore.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamingStore.API.DTO
{
    public class ProductsDTO
    {
        public string prodID { get; set; }
        public string catID { get; set; }
        public Categories category { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public decimal price { get; set; }
        public string genre { get; set; }
        public string[] images { get; set; }
    }
}
