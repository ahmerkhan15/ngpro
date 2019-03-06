using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace GamingStore.API.Models
{
    public class Products
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string prodID { get; set; }
        public string catID { get; set; }
        public Categories category { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public decimal price { get; set; }
        public string genre { get; set; }
        public string[] images { get; set; }

    }
}
