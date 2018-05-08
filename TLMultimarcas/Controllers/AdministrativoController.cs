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

        public ActionResult Funcionarios()
        {
            var users = db.Usuario;
            return View(users);
        }

        public ActionResult AdicionarFuncionario()
        {
            ViewBag.NomeFuncionario = new SelectList(db.Usuario, "NomeFuncionario");
            ViewBag.LoginFuncionario = new SelectList(db.Usuario, "LoginFuncionario");
            ViewBag.SenhaFuncionario = new SelectList(db.Usuario, "SenhaFuncionario");
            ViewBag.EmailFuncionario = new SelectList(db.Usuario, "EmailFuncionario");
            ViewBag.AdicionarFuncionario = new SelectList(db.Usuario, "AdicionarFuncionario");
            ViewBag.AdicionarVeiculo = new SelectList(db.Usuario, "AdicionarVeiculo");
            ViewBag.EditarFuncionario = new SelectList(db.Usuario, "EditarFuncionario");
            ViewBag.EditarVeiculo = new SelectList(db.Usuario, "EditarVeiculo");
            ViewBag.ExcluirFuncionario = new SelectList(db.Usuario, "ExcluirFuncionario");
            ViewBag.ExcluirVeiculo = new SelectList(db.Usuario, "ExcluirVeiculo");
            return View();
        }

        [HttpPost]
        public ActionResult AdicionarFuncionarios(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                db.Usuario.Add(usuario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.NomeFuncionario = new SelectList(db.Usuario, "NomeFuncionario", usuario.NomeFuncionario);
            ViewBag.LoginFuncionario = new SelectList(db.Usuario, "LoginFuncionario", usuario.LoginFuncionario);
            ViewBag.SenhaFuncionario = new SelectList(db.Usuario, "SenhaFuncionario", usuario.SenhaFuncionario);
            ViewBag.EmailFuncionario = new SelectList(db.Usuario, "EmailFuncionario", usuario.EmailFuncionario);
            ViewBag.AdicionarFuncionario = new SelectList(db.Usuario, "AdicionarFuncionario");
            ViewBag.AdicionarVeiculo = new SelectList(db.Usuario, "AdicionarVeiculo");
            ViewBag.EditarFuncionario = new SelectList(db.Usuario, "EditarFuncionario");
            ViewBag.EditarVeiculo = new SelectList(db.Usuario, "EditarVeiculo");
            ViewBag.ExcluirFuncionario = new SelectList(db.Usuario, "ExcluirFuncionario");
            ViewBag.ExcluirVeiculo = new SelectList(db.Usuario, "ExcluirVeiculo");
            return View(usuario);
        }
    }
}