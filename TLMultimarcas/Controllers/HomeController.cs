using System;
using System.Collections.Generic;
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
            var marcasArray = db.Marca.Select(x => new Marca
            {
                
            }).ToArray();
        }

        public ActionResult Chevrolet()
        {
            var chevrolet = from a in db.Veiculo
                            orderby a.IdMarca
                            where a.IdMarca == 3
                            select a;

            return View(chevrolet);
        }
    }
}