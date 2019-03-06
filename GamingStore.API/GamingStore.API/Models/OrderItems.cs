using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace GamingStore.API.Models
{
    public class OrderItems
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ordeItemID { get; set; }
        public string orderID { get; set; }
        public string prodID { get; set; }
        public decimal quantity { get; set; }
    }
}
