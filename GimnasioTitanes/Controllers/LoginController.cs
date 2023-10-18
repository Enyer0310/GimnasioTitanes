using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GimnasioTitanes.Models;

namespace GimnasioTitanes.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login

        private bd_titanesGymEntities bd = new bd_titanesGymEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Validar()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Validar(string rut,string pass)
        {
            login us = bd.login.FirstOrDefault(d => d.rut_usuario == rut & d.clave == pass);

            if (us != null)
            {
                return RedirectToAction("ListaMaestraPuestos", "Puesto");
            }
            else
            {
                return RedirectToAction("NoHallado", "Login");
            }
        }

        public ActionResult NoHallado()
        {
            ViewBag.Error = "No se encontró usuario";
            return View();
        }
    }
}