using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TLMultimarcas.Models;

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

    }
}