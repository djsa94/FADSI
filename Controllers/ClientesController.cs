using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoProgramado3.App_Start;
using ProyectoProgramado3.Models;
using MongoDB.Bson;
using System.Collections.Generic;
using MongoDB.Driver;
using MongoDB.Bson.IO;

namespace ProyectoProgramado3.Controllers
{
    public class ClientesController : Controller
    {
        private MongoCon _dbcontext;
        private IMongoCollection<ClienteModel> clientesCollection;

        public ClientesController()
        {
            _dbcontext = new MongoCon();
        }

            // GET: Clientes
            public ActionResult Index()
        {
            clientesCollection = _dbcontext.database.GetCollection<ClienteModel>("Clientes");
            var clientes = clientesCollection.AsQueryable<ClienteModel>().ToList<ClienteModel>();
            List<ClienteModel> list = new List<ClienteModel>();
            //list.Add(sitios);
            return View(clientes);
        }

        // GET: Clientes/Details/5
        public ActionResult Details(string id)
        {
            var SitiosDetails = _dbcontext.database.GetCollection<ClienteModel>("Clientes");
            var cliente = new ObjectId(id);
            var clienteId = SitiosDetails.AsQueryable<ClienteModel>().SingleOrDefault(x => x.Id == cliente);
            return View(clienteId);
        }

        // GET: Clientes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clientes/Create
        [HttpPost]
        public ActionResult Create(ClienteModel collection)
        {
            clientesCollection = _dbcontext.database.GetCollection<ClienteModel>("Clientes");
            clientesCollection.InsertOne(collection);
            Console.WriteLine("Insert");
            return RedirectToAction("Index");
        }

        // GET: Clientes/Edit/5
        public ActionResult Edit(string id)
        {
            clientesCollection = _dbcontext.database.GetCollection<ClienteModel>("Clientes");
            var clienteId = new ObjectId(id);
            var cliente = clientesCollection.AsQueryable<ClienteModel>().SingleOrDefault(x => x.Id == clienteId);
            return View(cliente);
        }

        // POST: Clientes/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, ClienteModel collection)
        {
            try
            {
                clientesCollection = _dbcontext.database.GetCollection<ClienteModel>("Clientes");
                clientesCollection.DeleteOne(Builders<ClienteModel>.Filter.Eq("_id", ObjectId.Parse(id)));
                Create(collection);
                var filter = Builders<ClienteModel>.Filter.Eq("_id", ObjectId.Parse(id));
                var update = Builders<ClienteModel>.Update.Set("Nombre", collection.Nombre);//Se puede agregar mas haciendo un .Set("",) extra
                var result = clientesCollection.UpdateOne(filter, update);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Clientes/Delete/5
        public ActionResult Delete(string id)
        {
            clientesCollection = _dbcontext.database.GetCollection<ClienteModel>("Clientes");
            var clienteId = new ObjectId(id);
            var cliente = clientesCollection.AsQueryable<ClienteModel>().SingleOrDefault(x => x.Id == clienteId);
            return View(cliente);
        }

        // POST: Clientes/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, ClienteModel collection)
        {
            try
            {
                clientesCollection = _dbcontext.database.GetCollection<ClienteModel>("Clientes");
                clientesCollection.DeleteOne(Builders<ClienteModel>.Filter.Eq("_id", ObjectId.Parse(id)));

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
