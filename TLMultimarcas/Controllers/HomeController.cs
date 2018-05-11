using System;
using System.Collections;
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

        public class Select
        {
            public string IdMarca;
            public string IdModelo;
            public string NomeModelo;
        }

        public ActionResult Data()
        {
            string str = "data source=.;initial catalog=TLMultimarcas;integrated security=True";
            SqlConnection con = new SqlConnection(str);
            string query = "SELECT IdMarca, Mo.IdModelo, Mo.NomeModelo FROM Veiculo V INNER JOIN Modelo Mo on Mo.IdModelo = V.IdModelo";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            var list = new List<Select>();
            while (rdr.Read())
            {
                list.Add(new Select { IdMarca = rdr[0].ToString(), IdModelo = rdr[1].ToString(), NomeModelo = rdr[2].ToString() });
            }
            return Json(list, JsonRequestBehavior.AllowGet);
        }
    }
}