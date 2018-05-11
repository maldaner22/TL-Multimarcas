using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TLMultimarcas.Models;

namespace TLMultimarcas.Controllers
{
    public class AdministrativoFuncionariosController : Controller
    {
        private TLMultimarcasEntities db = new TLMultimarcasEntities();

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