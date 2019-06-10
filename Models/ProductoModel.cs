using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ProyectoProgramado3.Models
{
    public class ProductoModel
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("idProducto")]
        public string idProducto { get; set; }

        [BsonElement("Nombre")]
        public string Nombre { get; set; }

        [BsonElement("Descripcion")]
        public string Descripcion { get; set; }

        [BsonElement("Precio")]
        public string Precio { get; set; }

        [BsonElement("Foto")]
        public string Foto { get; set; }
    }
}