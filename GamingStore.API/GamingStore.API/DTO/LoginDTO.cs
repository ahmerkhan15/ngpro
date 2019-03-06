using System.ComponentModel.DataAnnotations;

namespace GamingStore.API.DTO
{
    public class LoginDTO
    {
        [Required]
        public string userName { get; set; }
        public string password { get; set; }
    }
}
