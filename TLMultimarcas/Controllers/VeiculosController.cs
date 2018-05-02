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
        private TLMultimarcasEntities3 db = new TLMultimarcasEntities3();

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
    }
}