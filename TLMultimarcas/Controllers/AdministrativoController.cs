using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TLMultimarcas.Models;

namespace TLMultimarcas.Controllers
{
    public class AdministrativoController : Controller
    {
        private TLMultimarcasEntities3 db = new TLMultimarcasEntities3();

        public ActionResult Index()
        {
            var cars = db.Veiculo;
            return View(cars);
        }

        public ActionResult Adicionar()
        {
            ViewBag.IdModelo = new SelectList(db.Modelo, "IdModelo", "NomeModelo");
            ViewBag.IdMarca = new SelectList(db.Marca, "IdMarca", "NomeMarca");
            ViewBag.IdClasse = new SelectList(db.Classe, "IdClasse", "TipoClasse");
            ViewBag.IdPotencia = new SelectList(db.Potencia, "IdPotencia", "ValorPotencia");
            ViewBag.IdCombustivel = new SelectList(db.Combustivel, "IdCombustivel", "TipoCombustivel");
            ViewBag.IdCor = new SelectList(db.Cor, "IdCor", "TipoCor");
            ViewBag.IdCondicao = new SelectList(db.Condicao, "IdCondicao", "TipoCondicao");
            return View();
        }
    }
}