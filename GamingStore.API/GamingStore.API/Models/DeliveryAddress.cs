using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace GamingStore.API.Models
{
    public class DeliveryAddress
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string delAddID { get; set; }
        public string address { get; set; }
        public int postalCode { get; set; }
        public string email { get; set; }
        public string phone { get; set; }

    }
}
