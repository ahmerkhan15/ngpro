using GamingStore.API.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GamingStore.API.Services
{
    public class OrderItemsService
    {

        private readonly IMongoCollection<OrderItems> _orderItems;

        public OrderItemsService(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("GamingStoreDB"));
            var database = client.GetDatabase(config.GetSection("ConnectionStrings").GetSection("Database").Value);
            _orderItems = database.GetCollection<OrderItems>("OrderItems");
        }

        public async Task<List<OrderItems>> Get()
        {
            return await _orderItems.Find(x => true).ToListAsync();
        }

        public async Task<OrderItems> Get(string id)
        {
            return await _orderItems.Find(x => x.ordeItemID == id).FirstOrDefaultAsync();
        }

        public async Task<OrderItems> Create(OrderItems obj)
        {
            await _orderItems.InsertOneAsync(obj);
            return obj;
        }

        public async Task<List<OrderItems>> CreateBulk(List<OrderItems> obj)
        {
            await _orderItems.InsertManyAsync(obj);
            return obj;
        }

        public async Task Update(string id, OrderItems bookIn)
        {
            await _orderItems.ReplaceOneAsync(x => x.ordeItemID == id, bookIn);
        }

        public async Task Remove(string id)
        {
            await _orderItems.DeleteOneAsync(x => x.ordeItemID == id);
        }
    }
}
