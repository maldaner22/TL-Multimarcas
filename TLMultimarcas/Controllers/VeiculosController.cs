using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TLMultimarcas.Models;
using static TLMultimarcas.Controllers.HomeController;

namespace TLMultimarcas.Controllers
{
    public class VeiculosController : Controller
    {
        private TLMultimarcasEntities db = new TLMultimarcasEntities();

        public ActionResult Novos()
        {
            var condition = from a in db.Veiculo
                            orderby a.IdCondicao
                            where a.IdCondicao == 1
                            select a;

            return View(condition);
        }

        public ActionResult Seminovos()
        {
            var condition = from a in db.Veiculo
                            orderby a.IdCondicao
                            where a.IdCondicao == 2
                            select a;

            return View(condition);
        }

        public ActionResult Usados()
        {
            var condition = from a in db.Veiculo
                            orderby a.IdCondicao
                            where a.IdCondicao == 3
                            select a;

            return View(condition);
        }

        [HttpPost]
        public ActionResult Busca(string idMa, string idMo, string Val)
        {
            string str = "data source=.;initial catalog=TLMultimarcas;integrated security=True";
            SqlConnection con = new SqlConnection(str);
            string query = "SELECT Ma.IdMarca, Ma.NomeMarca, Mo.IdModelo, Mo.NomeModelo, P.ValorPotencia, C.TipoCombustivel, Co.TipoCondicao, Valor FROM Veiculo V INNER JOIN Modelo Mo on Mo.IdModelo = V.IdModelo INNER JOIN Marca Ma on Ma.IdMarca = V.IdMarca INNER JOIN Potencia P on P.IdPotencia = V.IdPotencia INNER JOIN Combustivel C on C.IdCombustivel = V.IdCombustivel INNER JOIN Condicao Co on Co.IdCondicao = V.IdCondicao";
            if (idMa != null)
            {
                System.Diagnostics.Debug.WriteLine("IdMarca - " + idMa);
                query = query + " WHERE Ma.IdMarca = " + idMa;
                if (idMo != null)
                {
                    System.Diagnostics.Debug.WriteLine("IdModelo - " + idMo);
                    query = query + " and Mo.IdModelo = " + idMo;
                }
                if (Val != null)
                {
                    System.Diagnostics.Debug.WriteLine("ValorConjunto - " + Val);
                    query = query + " and " + Val;
                }
                System.Diagnostics.Debug.WriteLine(query);
            }
            if (Val != null && idMa == null)
            {
                System.Diagnostics.Debug.WriteLine("ValorSolo - " + Val);
                query = query + " WHERE " + Val;
            }
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            var list = new List<Select>();
            while (rdr.Read())
            {
                list.Add(new Select
                {
                    IdMarca = rdr[0].ToString(),
                    NomeMarca = rdr[1].ToString(),
                    IdModelo = rdr[2].ToString(),
                    NomeModelo = rdr[3].ToString(),
                    ValorPotencia = rdr[4].ToString(),
                    TipoCombustivel = rdr[5].ToString(),
                    TipoCondicao = rdr[6].ToString(),
                    Valor = rdr[7].ToString()
                });
            }
            Session["result"] = list;
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Resultado()
        {
            var results = (List<Select>)Session["result"];
            return View(results);
        }

        public ActionResult Chevrolet()
        {
            var marca = from a in db.Veiculo
                        orderby a.IdMarca
                        where a.IdMarca == 3
                        select a;

            return View(marca);
        }

        public ActionResult Citroen()
        {
            var marca = from a in db.Veiculo
                        orderby a.IdMarca
                        where a.IdMarca == 4
                        select a;

            return View(marca);
        }

        public ActionResult Fiat()
        {
            var marca = from a in db.Veiculo
                        orderby a.IdMarca
                        where a.IdMarca == 5
                        select a;

            return View(marca);
        }

        public ActionResult Ford()
        {
            var marca = from a in db.Veiculo
                        orderby a.IdMarca
                        where a.IdMarca == 6
                        select a;

            return View(marca);
        }

        public ActionResult Honda()
        {
            var marca = from a in db.Veiculo
                        orderby a.IdMarca
                        where a.IdMarca == 7
                        select a;

            return View(marca);
        }

        public ActionResult Hyundai()
        {
            var marca = from a in db.Veiculo
                        orderby a.IdMarca
                        where a.IdMarca == 8
                        select a;

            return View(marca);
        }

        public ActionResult Peugeot()
        {
            var marca = from a in db.Veiculo
                        orderby a.IdMarca
                        where a.IdMarca == 9
                        select a;

            return View(marca);
        }

        public ActionResult Renault()
        {
            var marca = from a in db.Veiculo
                        orderby a.IdMarca
                        where a.IdMarca == 10
                        select a;

            return View(marca);
        }

        public ActionResult Toyota()
        {
            var marca = from a in db.Veiculo
                        orderby a.IdMarca
                        where a.IdMarca == 11
                        select a;

            return View(marca);
        }

        public ActionResult Volkswagen()
        {
            var marca = from a in db.Veiculo
                        orderby a.IdMarca
                        where a.IdMarca == 12
                        select a;

            return View(marca);
        }

    }
}
