using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MongoDB.Driver;

namespace ProyectoProgramado3.App_Start
{
    public class MongoCon
    {
        MongoClient client;
        public IMongoDatabase database;

        public MongoCon()
        {

            var client = new MongoClient("mongodb://Pri:dqUHYkepawhHhlLX@tp2-shard-00-00-2drvn.mongodb.net:27017,tp2-shard-00-01-2drvn.mongodb.net:27017,tp2-shard-00-02-2drvn.mongodb.net:27017/test?ssl=true&replicaSet=TP2-shard-0&authSource=admin&retryWrites=true");
            //var database = client.GetDatabase("LibreriaTEC-Nodo1");
            database = client.GetDatabase("LibreriaTEC-Nodo1");


            //(
            //database = mongoClient.GetDatabase(ConfigurationManager.AppSettings["MongoDBName"]);

        }
    }
}