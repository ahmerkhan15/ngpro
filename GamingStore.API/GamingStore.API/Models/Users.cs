using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace GamingStore.API.Models
{
    public class Users
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string userID { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public string fName { get; set; }
        public string lName { get; set; }
        public int postalCode { get; set; }
        public string address { get; set; }
        public string email { get; set; }
        public string cellphone { get; set; }
        public bool isAdmin { get; set; }
    }
}
