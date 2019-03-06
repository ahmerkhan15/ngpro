using GamingStore.API.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamingStore.API.Services
{
    public class StatusService
    {
        private readonly IMongoCollection<Status> _status;

        public StatusService(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("GamingStoreDB"));
            var database = client.GetDatabase(config.GetSection("ConnectionStrings").GetSection("Database").Value);
            _status = database.GetCollection<Status>("Status");
        }

        public async Task<List<Status>> Get()
        {
            return await _status.Find(x => true).ToListAsync();
        }

        public async Task<Status> Get(string id)
        {
            return await _status.Find(x => x.statusID == id).FirstOrDefaultAsync();
        }

        public async Task<Status> Create(Status obj)
        {
            await _status.InsertOneAsync(obj);
            return obj;
        }

        public async Task Update(string id, Status bookIn)
        {
            await _status.ReplaceOneAsync(x => x.statusID == id, bookIn);
        }

        public async Task Remove(string id)
        {
            await _status.DeleteOneAsync(x => x.statusID == id);
        }
    }
}
