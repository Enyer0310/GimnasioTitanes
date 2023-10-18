using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GimnasioTitanes.Models;

namespace GimnasioTitanes.Controllers
{
    public class MantenimientoVentaSuplementoController : Controller
    {
        private bd_titanesGymEntities db = new bd_titanesGymEntities();

        // GET: MantenimientoVentaSuplemento
        public ActionResult Index()
        {
            var ventaSuplemento = db.ventaSuplemento.Include(v => v.suplemento).Include(v => v.usuario);
            return View(ventaSuplemento.ToList());
        }

        // GET: MantenimientoVentaSuplemento/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ventaSuplemento ventaSuplemento = db.ventaSuplemento.Find(id);
            if (ventaSuplemento == null)
            {
                return HttpNotFound();
            }
            return View(ventaSuplemento);
        }

        // GET: MantenimientoVentaSuplemento/Create
        public ActionResult Create()
        {
            ViewBag.id_suplemento = new SelectList(db.suplemento, "id_suplemento", "nom_suplemento");
            ViewBag.rut_usuario = new SelectList(db.usuario, "rut_usuario", "usu_nombre");
            return View();
        }

        // POST: MantenimientoVentaSuplemento/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_ventaSuplemento,fecha_ventaSuplemto,rut_usuario,id_suplemento,cantidad_suplemento,venta_suplemento")] ventaSuplemento ventaSuplemento)
        {
            if (ModelState.IsValid)
            {
                db.ventaSuplemento.Add(ventaSuplemento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_suplemento = new SelectList(db.suplemento, "id_suplemento", "nom_suplemento", ventaSuplemento.id_suplemento);
            ViewBag.rut_usuario = new SelectList(db.usuario, "rut_usuario", "usu_nombre", ventaSuplemento.rut_usuario);
            return View(ventaSuplemento);
        }

        // GET: MantenimientoVentaSuplemento/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ventaSuplemento ventaSuplemento = db.ventaSuplemento.Find(id);
            if (ventaSuplemento == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_suplemento = new SelectList(db.suplemento, "id_suplemento", "nom_suplemento", ventaSuplemento.id_suplemento);
            ViewBag.rut_usuario = new SelectList(db.usuario, "rut_usuario", "usu_nombre", ventaSuplemento.rut_usuario);
            return View(ventaSuplemento);
        }

        // POST: MantenimientoVentaSuplemento/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_ventaSuplemento,fecha_ventaSuplemto,rut_usuario,id_suplemento,cantidad_suplemento,venta_suplemento")] ventaSuplemento ventaSuplemento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ventaSuplemento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_suplemento = new SelectList(db.suplemento, "id_suplemento", "nom_suplemento", ventaSuplemento.id_suplemento);
            ViewBag.rut_usuario = new SelectList(db.usuario, "rut_usuario", "usu_nombre", ventaSuplemento.rut_usuario);
            return View(ventaSuplemento);
        }

        // GET: MantenimientoVentaSuplemento/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ventaSuplemento ventaSuplemento = db.ventaSuplemento.Find(id);
            if (ventaSuplemento == null)
            {
                return HttpNotFound();
            }
            return View(ventaSuplemento);
        }

        // POST: MantenimientoVentaSuplemento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ventaSuplemento ventaSuplemento = db.ventaSuplemento.Find(id);
            db.ventaSuplemento.Remove(ventaSuplemento);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
