using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

using MongoDB.Driver;

namespace ProyectoProgramado3.App_Start
{
    public class MongoCon
    {
        MongoClient client;
        public IMongoDatabase database;
        private static string _connectionString = ConfigurationManager.ConnectionStrings["MongoDB"].ToString();

        public MongoCon()
        {

            var client = new MongoClient(_connectionString);
            database = client.GetDatabase("FADSI");

        }
    }
}