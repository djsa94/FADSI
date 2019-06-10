using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ProyectoProgramado3.Models
{
    public class Sitio_productoModel
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("idProducto")]
        public string idProducto { get; set; }

        [BsonElement("idSitio")]
        public string idSitio { get; set; }
    }
}