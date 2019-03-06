using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace GamingStore.API.Models
{
    public class Status
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string statusID { get; set; }
        public string name { get; set; }
    }
}
