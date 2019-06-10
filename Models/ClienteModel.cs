using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ProyectoProgramado3.Models
{
    public class ClienteModel
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("idCliente")]
        public string idCliente { get; set; }

        [BsonElement("Nombre")]
        public string Nombre { get; set; }

        [BsonElement("Telefono")]
        public string Telefono { get; set; }

        [BsonElement("Correo")]
        public string Correo { get; set; }

        [BsonElement("Nacimiento")]
        public string Nacimiento { get; set; }

        [BsonElement("Contrasenna")]
        public string Contrasenna { get; set; }
    }
}