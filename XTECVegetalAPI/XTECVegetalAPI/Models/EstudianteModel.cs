using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XTECVegetalAPI.Models
{
    public class EstudianteModel
    {
        [BsonId]
        public ObjectId estudiante { get; set; }
        [BsonRequired]
        public string Carne { get; set; }
        public string Nombre { get; set; }
        public string CorreoElectronico { get; set; }
        public string Telefono { get; set; }
        public string Password { get; set; }
    }
}
