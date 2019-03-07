using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamingStore.API.DTO
{
    public class SignUpDTO
    {
        public string userName { get; set; }
        public string password { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public int postalCode { get; set; }
        public string address { get; set; }
        public string email { get; set; }
        public string cellphone { get; set; }
    }
}
