using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication1.Models;

namespace MvcApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Bem Vindo a Rede de Compartilhamento!";

            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View(new Conexao());
        }
    }
}
