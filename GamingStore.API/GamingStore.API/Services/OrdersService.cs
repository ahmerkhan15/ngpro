using GamingStore.API.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GamingStore.API.Services
{
    public class OrdersService
    {
        private readonly IMongoCollection<Orders> _orders;

        public OrdersService(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("GamingStoreDB"));
            var database = client.GetDatabase(config.GetSection("ConnectionStrings").GetSection("Database").Value);
            _orders = database.GetCollection<Orders>("Orders");
        }

        public async Task<List<Orders>> Get()
        {
            return await _orders.Find(x => true).ToListAsync();
        }

        public async Task<Orders> Get(string id)
        {
            return await _orders.Find(x => x.orderID == id).FirstOrDefaultAsync();
        }

        public async Task<Orders> Create(Orders obj)
        {
            await _orders.InsertOneAsync(obj);
            return obj;
        }

        public async Task Update(string id, Orders bookIn)
        {
            await _orders.ReplaceOneAsync(x => x.orderID == id, bookIn);
        }

        public async Task Remove(string id)
        {
            await _orders.DeleteOneAsync(x => x.orderID == id);
        }
    }
}
