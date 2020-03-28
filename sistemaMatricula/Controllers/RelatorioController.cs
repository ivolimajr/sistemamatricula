using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace sistemaMatricula.Controllers
{
    public class RelatorioController : Controller
    {
        // GET: Relatorio
        public ActionResult Index()
        {
            return View();
        }
        // GET: Relatorio
        public ActionResult RelatorioTurma()
        {

            return View();
        }
    }
}