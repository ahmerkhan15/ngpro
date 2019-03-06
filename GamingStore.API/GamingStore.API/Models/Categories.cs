
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace GamingStore.API.Models
{
    public class Categories
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string catID { get; set; }
        public string name { get; set; }
        public string description { get; set; }

    }
}
