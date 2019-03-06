using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace GamingStore.API.Models
{
    public class OrderItems
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ordeItemID { get; set; }
        public int orderID { get; set; }
        public int prodID { get; set; }
        public decimal quantity { get; set; }
    }
}
