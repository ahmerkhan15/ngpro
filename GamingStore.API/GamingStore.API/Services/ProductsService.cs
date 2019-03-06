using GamingStore.API.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GamingStore.API.Services
{
    public class ProductsService
    {
        private readonly IMongoCollection<Products> _products;

        public ProductsService(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("GamingStoreDB"));
            var database = client.GetDatabase(config.GetSection("ConnectionStrings").GetSection("Database").Value);
            _products = database.GetCollection<Products>("Products");
        }

        public async Task<List<Products>> Get()
        {
            return await _products.Find(x => true).ToListAsync();
        }

        public async Task<Products> Get(string id)
        {
            return await _products.Find(x => x.prodID == id).FirstOrDefaultAsync();
        }

        public async Task<List<Products>> GetByCategoryID(string catID)
        {
            return await _products.Find(x => x.catID == catID).ToListAsync();
        }

        public async Task<Products> Create(Products obj)
        {
            await _products.InsertOneAsync(obj);
            return obj;
        }

        public async Task Update(string id, Products bookIn)
        {
            await _products.ReplaceOneAsync(x => x.prodID == id, bookIn);
        }

        public async Task Remove(string id)
        {
            await _products.DeleteOneAsync(x => x.prodID == id);
        }
    }
}
