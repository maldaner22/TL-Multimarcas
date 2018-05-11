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

        public ActionResult Data()
        {
            string str = "data source=.;initial catalog=TLMultimarcas;integrated security=True";
            SqlConnection con = new SqlConnection(str);
            string query = "SELECT IdMarca, Mo.NomeModelo FROM Veiculo V INNER JOIN Modelo Mo on Mo.IdModelo = V.IdModelo";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            List<SelectListItem> li = new List<SelectListItem>();
            while (rdr.Read())
            {
                li.Add(new SelectListItem { Text = rdr[1].ToString(), Value = rdr[0].ToString() });
            }
            return Json(li, JsonRequestBehavior.AllowGet);
        }
    }
}