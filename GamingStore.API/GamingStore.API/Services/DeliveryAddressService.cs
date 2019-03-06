using GamingStore.API.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GamingStore.API.Services
{
    public class DeliveryAddressService
    {

        private readonly IMongoCollection<DeliveryAddress> _deliveryAddress;

        public DeliveryAddressService(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("GamingStoreDB"));
            var database = client.GetDatabase(config.GetSection("ConnectionStrings").GetSection("Database").Value);
            _deliveryAddress = database.GetCollection<DeliveryAddress>("DeliveryAddress");
        }

        public async Task<List<DeliveryAddress>> Get()
        {
            return await _deliveryAddress.Find(x => true).ToListAsync();
        }

        public async Task<DeliveryAddress> Get(string id)
        {
            return await _deliveryAddress.Find(x => x.delAddID == id).FirstOrDefaultAsync();
        }

        public async Task<DeliveryAddress> Create(DeliveryAddress obj)
        {
            await _deliveryAddress.InsertOneAsync(obj);
            return obj;
        }

        public async Task Update(string id, DeliveryAddress bookIn)
        {
            await _deliveryAddress.ReplaceOneAsync(x => x.delAddID == id, bookIn);
        }

        public async Task Remove(string id)
        {
            await _deliveryAddress.DeleteOneAsync(x => x.delAddID == id);
        }
    }
}
