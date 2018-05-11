using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TLMultimarcas.Models;

namespace TLMultimarcas.Controllers
{
    public class AdministrativoController : Controller
    {
        private TLMultimarcasEntities db = new TLMultimarcasEntities();

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

        [HttpPost]
        public ActionResult Adicionar(Veiculo veiculo)
        {
            if (ModelState.IsValid)
            {
                db.Veiculo.Add(veiculo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdModelo = new SelectList(db.Modelo, "IdModelo","NomeModelo", veiculo.Modelo);
            ViewBag.IdMarca = new SelectList(db.Marca, "IdMarca", "NomeMarca", veiculo.Marca);
            ViewBag.IdClasse = new SelectList(db.Classe, "IdClasse", "TipoClasse", veiculo.Classe);
            ViewBag.IdPotencia = new SelectList(db.Potencia, "IdPotencia", "ValorPotencia", veiculo.Potencia);
            ViewBag.IdCombustivel = new SelectList(db.Combustivel, "IdCombustivel", "TipoCombustivel", veiculo.Combustivel);
            ViewBag.IdCor = new SelectList(db.Cor, "IdCor", "TipoCor", veiculo.Cor);
            ViewBag.IdCondicao = new SelectList(db.Condicao, "IdCondicao", "TipoCondicao", veiculo.Condicao);
            return View(veiculo);
        }

        public ActionResult Editar(long id)
        {
            Veiculo veiculo = db.Veiculo.Find(id);
            ViewBag.IdModelo = new SelectList(db.Modelo, "IdModelo", "NomeModelo", veiculo.IdModelo);
            ViewBag.IdMarca = new SelectList(db.Marca, "IdMarca", "NomeMarca", veiculo.IdMarca);
            ViewBag.IdClasse = new SelectList(db.Classe, "IdClasse", "TipoClasse", veiculo.IdClasse);
            ViewBag.IdPotencia = new SelectList(db.Potencia, "IdPotencia", "ValorPotencia", veiculo.IdPotencia);
            ViewBag.IdCombustivel = new SelectList(db.Combustivel, "IdCombustivel", "TipoCombustivel", veiculo.IdCombustivel);
            ViewBag.IdCor = new SelectList(db.Cor, "IdCor", "TipoCor", veiculo.IdCor);
            ViewBag.IdCondicao = new SelectList(db.Condicao, "IdCondicao", "TipoCondicao", veiculo.IdCondicao);
            return View(veiculo);
        }

        [HttpPost]
        public ActionResult Editar(Veiculo veiculo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(veiculo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdModelo = new SelectList(db.Modelo, "IdModelo", "NomeModelo", veiculo.IdModelo);
            ViewBag.IdMarca = new SelectList(db.Marca, "IdMarca", "NomeMarca", veiculo.IdMarca);
            ViewBag.IdClasse = new SelectList(db.Classe, "IdClasse", "TipoClasse", veiculo.IdClasse);
            ViewBag.IdPotencia = new SelectList(db.Potencia, "IdPotencia", "ValorPotencia", veiculo.IdPotencia);
            ViewBag.IdCombustivel = new SelectList(db.Combustivel, "IdCombustivel", "TipoCombustivel", veiculo.IdCombustivel);
            ViewBag.IdCor = new SelectList(db.Cor, "IdCor", "TipoCor", veiculo.IdCor);
            ViewBag.IdCondicao = new SelectList(db.Condicao, "IdCondicao", "TipoCondicao", veiculo.IdCondicao);
            return View(veiculo);
        }

        [HttpPost]
        public string Excluir(long id)
        {
            try
            {
                Veiculo veiculo = db.Veiculo.Find(id);
                db.Veiculo.Remove(veiculo);
                db.SaveChanges();
                return Boolean.TrueString;
            }
            catch
            {
                return Boolean.FalseString;
            }
        }
    }
}