using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
namespace Infraestructure.Infrastructure.Data.DataModels
{
    public class RegisterUsers
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("Identificador")]
        public string Identificador { get; set; }
        [BsonElement("Password")]
        public string Password { get; set; }
       
    }
   
    }
