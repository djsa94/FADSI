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
    public class SitiosController : Controller
    {
        private MongoCon _dbcontext;
        private IMongoCollection<SitiosModel> sitiosCollection;

        public SitiosController()
        {
            _dbcontext = new MongoCon();
        }

        // GET: Sitios
        public ActionResult Index()
        {
            sitiosCollection = _dbcontext.database.GetCollection<SitiosModel>("Sitios");
            var sitios = sitiosCollection.AsQueryable<SitiosModel>().ToList<SitiosModel>();
            List<SitiosModel> list = new List<SitiosModel>();
            //list.Add(sitios);
            return View(sitios);
        }

        // GET: Sitios/Details/5
        public ActionResult Details(string id)
        {
            var SitiosDetails = _dbcontext.database.GetCollection<SitiosModel>("Sitios");
            var sitios = new ObjectId(id);
            var sitiosid = SitiosDetails.AsQueryable<SitiosModel>().SingleOrDefault(x => x.Id == sitios);
            return View(sitiosid);
        }

        // GET: Sitios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sitios/Create
        [HttpPost]
        public ActionResult Create(SitiosModel collection)
        {
            sitiosCollection = _dbcontext.database.GetCollection<SitiosModel>("Sitios");
            sitiosCollection.InsertOne(collection);
            Console.WriteLine("Insert");
            return RedirectToAction("Index");
        }

        // GET: Sitios/Edit/5
        public ActionResult Edit(string id)
        {
            sitiosCollection = _dbcontext.database.GetCollection<SitiosModel>("Sitios");
            var SitiosId = new ObjectId(id);
            var sitios = sitiosCollection.AsQueryable<SitiosModel>().SingleOrDefault(x => x.Id == SitiosId);
            return View(sitios);
        }

        // POST: Sitios/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, SitiosModel collection)
        {
            try
            {
                sitiosCollection = _dbcontext.database.GetCollection<SitiosModel>("Sitios");
                sitiosCollection.DeleteOne(Builders<SitiosModel>.Filter.Eq("_id", ObjectId.Parse(id)));
                Create(collection);
                var filter = Builders<SitiosModel>.Filter.Eq("_id", ObjectId.Parse(id));
                var update = Builders<SitiosModel>.Update.Set("Nombre", collection.Nombre);//Se puede agregar mas haciendo un .Set("",) extra
                var result = sitiosCollection.UpdateOne(filter, update);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Sitios/Delete/5
        public ActionResult Delete(string id)
        {
            sitiosCollection = _dbcontext.database.GetCollection<SitiosModel>("Sitios");
            var sitiosId = new ObjectId(id);
            var sitios = sitiosCollection.AsQueryable<SitiosModel>().SingleOrDefault(x => x.Id == sitiosId);
            return View(sitios);
        }

        // POST: Sitios/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, SitiosModel collection)
        {
            try
            {
                sitiosCollection = _dbcontext.database.GetCollection<SitiosModel>("Sitios");
                sitiosCollection.DeleteOne(Builders<SitiosModel>.Filter.Eq("_id", ObjectId.Parse(id)));

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
