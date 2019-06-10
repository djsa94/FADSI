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
    public class PedidosController : Controller
    {
        private MongoCon _dbcontext;
        private IMongoCollection<PedidosModel> pedCollection;

        public PedidosController()
        {
            _dbcontext = new MongoCon();
        }

        // GET: Pedidos
        public ActionResult Index()
        {
            pedCollection = _dbcontext.database.GetCollection<PedidosModel>("Pedidos");
            var pedidos = pedCollection.AsQueryable<PedidosModel>().ToList<PedidosModel>();
            List<PedidosModel> list = new List<PedidosModel>();
            //list.Add(sitios);
            return View(pedidos);
        }

        // GET: Pedidos/Details/5
        public ActionResult Details(string id)
        {
            var PedidosDetails = _dbcontext.database.GetCollection<PedidosModel>("Pedidos");
            var pedidos = new ObjectId(id);
            var pedidosId = PedidosDetails.AsQueryable<PedidosModel>().SingleOrDefault(x => x.Id == pedidos);
            return View(pedidosId);
        }

        // GET: Pedidos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pedidos/Create
        [HttpPost]
        public ActionResult Create(PedidosModel collection)
        {
            pedCollection = _dbcontext.database.GetCollection<PedidosModel>("Pedidos");
            pedCollection.InsertOne(collection);
            Console.WriteLine("Insert");
            return RedirectToAction("Index");
        }

        // GET: Pedidos/Edit/5
        public ActionResult Edit(string id)
        {
            pedCollection = _dbcontext.database.GetCollection<PedidosModel>("Pedidos");
            var pedidoId = new ObjectId(id);
            var pedido = pedCollection.AsQueryable<PedidosModel>().SingleOrDefault(x => x.Id == pedidoId);
            return View(pedido);
        }

        // POST: Pedidos/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, PedidosModel collection)
        {
            try
            {
                pedCollection = _dbcontext.database.GetCollection<PedidosModel>("Pedidos");
                pedCollection.DeleteOne(Builders<PedidosModel>.Filter.Eq("_id", ObjectId.Parse(id)));
                Create(collection);
                var filter = Builders<PedidosModel>.Filter.Eq("_id", ObjectId.Parse(id));
                var update = Builders<PedidosModel>.Update.Set("Numero Pedido", collection.idPedido);//Se puede agregar mas haciendo un .Set("",) extra
                var result = pedCollection.UpdateOne(filter, update);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Pedidos/Delete/5
        public ActionResult Delete(string id)
        {
            pedCollection = _dbcontext.database.GetCollection<PedidosModel>("Pedidos");
            var pedidosId = new ObjectId(id);
            var pedidos = pedCollection.AsQueryable<PedidosModel>().SingleOrDefault(x => x.Id == pedidosId);
            return View(pedidos);
        }

        // POST: Pedidos/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, PedidosModel collection)
        {
            try
            {
                pedCollection = _dbcontext.database.GetCollection<PedidosModel>("Pedidos");
                pedCollection.DeleteOne(Builders<PedidosModel>.Filter.Eq("_id", ObjectId.Parse(id)));

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
