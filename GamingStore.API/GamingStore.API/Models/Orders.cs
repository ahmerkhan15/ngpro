using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace GamingStore.API.Models
{
    public class Orders
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string orderID { get; set; }
        public string sessionID { get; set; }
        public string customerID { get; set; }
        public int delAddressID { get; set; }
        public DateTime date { get; set; }
        public int statusID { get; set; }
        public decimal total { get; set; }
        public List<OrderItems> items { get; set; }
    }
}
