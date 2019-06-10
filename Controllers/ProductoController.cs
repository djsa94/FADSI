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
    public class ProductoController : Controller
    {
        private MongoCon _dbcontext;
        private IMongoCollection<ProductoModel> prodCollection;

        public ProductoController()
        {
            _dbcontext = new MongoCon();
        }

        // GET: Producto
        public ActionResult Index()
        {
            prodCollection = _dbcontext.database.GetCollection<ProductoModel>("Productos");
            var productos = prodCollection.AsQueryable<ProductoModel>().ToList<ProductoModel>();
            List<ProductoModel> list = new List<ProductoModel>();
            //list.Add(sitios);
            return View(productos);
        }

        // GET: Producto/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Producto/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Producto/Create
        [HttpPost]
        public ActionResult Create(ProductoModel collection)
        {
            prodCollection = _dbcontext.database.GetCollection<ProductoModel>("Productos");
            prodCollection.InsertOne(collection);
            Console.WriteLine("Insert");
            return RedirectToAction("Index");
        }

        // GET: Producto/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Producto/Edit/5
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

        // GET: Producto/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Producto/Delete/5
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
