using GamingStore.API.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GamingStore.API.Services
{
    public class UsersService
    {
        private readonly IMongoCollection<Users> _users;

        public UsersService(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("GamingStoreDB"));
            var database = client.GetDatabase(config.GetSection("ConnectionStrings").GetSection("Database").Value);
            _users = database.GetCollection<Users>("Users");
        }

        public async Task<List<Users>> Get()
        {
            return await _users.Find(x => true).ToListAsync();
        }

        public async Task<Users> Get(string id)
        {
            return await _users.Find(x => x.userID == id).FirstOrDefaultAsync();
        }

        public async Task<Users> Create(Users obj)
        {
            await _users.InsertOneAsync(obj);
            return obj;
        }

        public async Task Update(string id, Users bookIn)
        {
            await _users.ReplaceOneAsync(x => x.userID == id, bookIn);
        }

        public async Task Remove(string id)
        {
            await _users.DeleteOneAsync(x => x.userID == id);
        }
    }
}
