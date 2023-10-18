using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GimnasioTitanes.Models;

namespace GimnasioTitanes.Controllers
{
    public class PuestoController : Controller
    {
        // GET: Puesto

        bd_titanesGymEntities entidad = new bd_titanesGymEntities();

        public ActionResult Index()
        {
            var listapuestoss = entidad.puesto;
            return View(listapuestoss.ToList());
        }

        public ActionResult ListaMaestraPuestos()
        {
            var listapuestos = entidad.puesto;
            return View(listapuestos.ToList());
        }

        public ActionResult Usuario(int puesto)
        {
            var modelo = from p in entidad.usuario where p.puesto.id_puesto == puesto select p;
            return View(modelo.ToList());
        }

    }
} 