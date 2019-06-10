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
            var sitios = sitiosCollection.AsQueryable<SitiosModel>().SingleOrDefault(u => u.idSitio.Equals(Session["SessionID"]));
            List<SitiosModel> list = new List<SitiosModel>();
            list.Add(sitios);
            return View(list);
        }

        // GET: Sitios/Details/5
        public ActionResult Details(int id)
        {
            return View();
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
            return RedirectToAction("/Home/Index");
        }

        // GET: Sitios/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Sitios/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Sitios/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Sitios/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
