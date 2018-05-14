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
            var brands = db.Marca.ToList();
            SelectList list = new SelectList(brands, "IdMarca", "NomeMarca");
            ViewBag.brandsname = list;
            return View();
        }

        public class Select
        {
            public string IdMarca;
            public string NomeMarca;
            public string IdModelo;
            public string NomeModelo;
            public string ValorPotencia;
            public string Valor;
        }

        [HttpPost]
        public ActionResult Data()
        {
            string str = "data source=.;initial catalog=TLMultimarcas;integrated security=True";
            SqlConnection con = new SqlConnection(str);
            string query = "SELECT Ma.IdMarca, Ma.NomeMarca, Mo.IdModelo, Mo.NomeModelo, P.ValorPotencia, Valor FROM Veiculo V INNER JOIN Modelo Mo on Mo.IdModelo = V.IdModelo INNER JOIN Marca Ma on Ma.IdMarca = V.IdMarca INNER JOIN Potencia P on P.IdPotencia = V.IdPotencia";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            var list = new List<Select>();
            while (rdr.Read())
            {
                list.Add(new Select { IdMarca = rdr[0].ToString(), IdModelo = rdr[2].ToString(), NomeModelo = rdr[3].ToString() });
            }
            return Json(list, JsonRequestBehavior.AllowGet);
        }
    }
}