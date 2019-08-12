using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructure.Infrastructure.Data.DataModels
{
    public class Users
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("Nombre")]
        public string Name { get; set; }
        [BsonElement("Apellidos")]
        public string LastName { get; set; }
        [BsonElement("Identificador")]
        public string Identified { get; set; }
        [BsonElement("Hora_Entrada")]
        public string HourEnter { get; set; }
        [BsonElement("Hora_Salida")]
        public string Hourleft { get; set; }


    }
}
