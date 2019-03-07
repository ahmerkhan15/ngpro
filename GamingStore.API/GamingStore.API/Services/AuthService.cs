using GamingStore.API.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System.Threading.Tasks;

namespace GamingStore.API.Services
{
    public class AuthService
    {
        private readonly IMongoCollection<Users> _users;

        public AuthService(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("GamingStoreDB"));
            var database = client.GetDatabase(config.GetSection("ConnectionStrings").GetSection("Database").Value);
            _users = database.GetCollection<Users>("Users");
        }

        public async Task<Users> Login(string userName, string password)
        {
            var obj= await _users.Find(zx => zx.userName == userName && zx.password == password).FirstOrDefaultAsync();
            if (obj == null) { return null; }
            return obj;
        }

        public async Task<string> SignUp(string userName,string password,string firstName,string lastName,int postalCode,string address,string cellphone, string email)
        {
            var user = new Users() { userName = userName, fName = firstName ,lName = lastName, password = password,postalCode=postalCode,address=address,cellphone=cellphone,email=email};
            await _users.InsertOneAsync(user);
            return user.userID;
        }
    }
}
