using sistemaMatricula.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace sistemaMatricula.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Autenticacao(usuario usuario)
        {
            using (sistemaMatriculaDesktop db = new sistemaMatriculaDesktop())
            {
                usuario.senha = Crypt.Hash(usuario.senha);
                var usuarioDetalhe = db.usuario.Where(x => x.login == usuario.login && x.senha == usuario.senha).FirstOrDefault();
                if (usuarioDetalhe == null)
                {
                    usuario.LoginErrorMessage = "Dados Inválidos";
                    return View("Login", usuario);
                }
                else
                {
                    Session["UserId"] = usuarioDetalhe.id;
                    Session["UserName"] = usuarioDetalhe.login;
                    return RedirectToAction("Index", "Home");
                }
            }
        }
        public ActionResult Logout()
        {
            int userId = (int)Session["UserId"];
            Session.Abandon();
            return RedirectToAction("Login", "Home");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}