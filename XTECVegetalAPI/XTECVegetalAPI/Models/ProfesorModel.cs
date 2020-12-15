using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XTECVegetalAPI.Models
{
    public class ProfesorModel
    {
        [BsonId]
        public ObjectId profesor { get; set; }
        [BsonRequired]
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public string CorreoElectronico { get; set; }
        public string Telefono { get; set; }
        public string Password { get; set; }
    }
}
