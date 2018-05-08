using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TLMultimarcas.Models;

namespace TLMultimarcas.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Autorizado(TLMultimarcas.Models.Usuario userModel)
        {
            using (TLMultimarcasEntities db = new TLMultimarcasEntities())
            {
                var userDetails = db.Usuario.Where(x => x.LoginFuncionario == userModel.LoginFuncionario && x.SenhaFuncionario == userModel.SenhaFuncionario).FirstOrDefault();
                if (userDetails == null)
                {
                    userModel.LoginErrorMessage = "Usuário ou senha incorretos.";
                    return View("Index", userModel);
                }
                else
                {
                    Session["IdUsuario"] = userDetails.IdUsuario;
                    Session["AdicionarVeiculo"] = userDetails.AdicionarVeiculo;
                    Session["EditarVeiculo"] = userDetails.EditarVeiculo;
                    Session["ExcluirVeiculo"] = userDetails.ExcluirVeiculo;
                    if (Session["AdicionarVeiculo"].ToString() == "0")
                    {
                        Session["AdicionarVeiculo"] = null;
                    }
                    if (Session["EditarVeiculo"].ToString() == "0")
                    {
                        Session["EditarVeiculo"] = null;
                    }
                    if (Session["ExcluirVeiculo"].ToString() == "0")
                    {
                        Session["ExcluirVeiculo"] = null;
                    }
                    return RedirectToAction("Index", "Administrativo");
                }
            }
        }
    }
}