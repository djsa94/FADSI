using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ProyectoProgramado3.Models
{
    public class PedidosModel
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("idPedido")]
        public string idPedido { get; set; }

        [BsonElement("idCliente")]
        public string idCliente { get; set; }

        [BsonElement("Cantidad")]
        public string Cantidad { get; set; }

        [BsonElement("Precio")]
        public string Precio { get; set; }

        [BsonElement("Fecha")]
        public string Fecha { get; set; }

        [BsonElement("Hora")]
        public string Hora { get; set; }

        [BsonElement("Estado")]
        public string Estado { get; set; }

        [BsonElement("Ingredientes_extras")]
        public string Ingredientes_extras { get; set; }
    }
}