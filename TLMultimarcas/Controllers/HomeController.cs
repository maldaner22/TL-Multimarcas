using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TLMultimarcas.Models;

namespace TLMultimarcas.Controllers
{
    public class HomeController : Controller
    {
        private TLMultimarcasEntities db = new TLMultimarcasEntities();

        public ActionResult Index()
        {
            //var brands = db.Marca;
            //return View(brands);
            var brands = db.Marca.ToList();
            SelectList list = new SelectList(brands, "IdMarca", "NomeMarca");
            ViewBag.brandsname = list;
            return View();
        }
    }
}