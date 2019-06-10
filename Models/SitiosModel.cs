using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ProyectoProgramado3.Models
{
    public class SitiosModel
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("idSitio")]
        public string idSitio { get; set; }

        [BsonElement("Latitud")]
        public string Latitud { get; set; }

        [BsonElement("Longitud")]
        public string Longitud { get; set; }

        [BsonElement("Direccion")]
        public string Direccion { get; set; }

        [BsonElement("Nombre")]
        public string Nombre { get; set; }

        [BsonElement("Descripcion")]
        public string Descripcion { get; set; }

        [BsonElement("Cantidad_repartidores")]
        public string Cantidad_repartidores { get; set; }

        [BsonElement("Tipo_lugar")]
        public string Tipo_lugar { get; set; }

        [BsonElement("Imagen")]
        public double Imagen { get; set; }

        [BsonElement("Telefono")]
        public string Telefono { get; set; }

        [BsonElement("Rating")]
        public string Rating { get; set; }

        [BsonElement("Horario")]
        public string Horario { get; set; }

        [BsonElement("Website")]
        public string Website { get; set; }
    }
}
