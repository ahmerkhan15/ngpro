using GamingStore.API.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GamingStore.API.Services
{
    public class CategoryService
    {
        private readonly IMongoCollection<Categories> _categories;

        public CategoryService(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("GamingStoreDB"));
            var database = client.GetDatabase(config.GetSection("ConnectionStrings").GetSection("Database").Value);
            _categories = database.GetCollection<Categories>("Categories");
        }

        public async Task<List<Categories>> Get()
        {
            return await _categories.Find(x => true).ToListAsync();
        }

        public async Task<Categories> Get(string id)
        {
            return await _categories.Find(x => x.catID == id).FirstOrDefaultAsync();
        }

        public async Task<Categories> Create(Categories obj)
        {
            await _categories.InsertOneAsync(obj);
            return obj;
        }

        public async Task Update(string id, Categories bookIn)
        {
            await _categories.ReplaceOneAsync(x => x.catID == id, bookIn);
        }

        public async Task Remove(string id)
        {
            await _categories.DeleteOneAsync(x => x.catID == id);
        }
    }
}
