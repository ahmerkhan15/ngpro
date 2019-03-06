using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace GamingStore.API.Models
{
    public class Orders
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string orderID { get; set; }
        public Guid sessionID { get; set; }
        public int customerID { get; set; }
        public int delAddressID { get; set; }
        public DateTime date { get; set; }
        public int statusID { get; set; }
        public decimal total { get; set; }

    }
}
