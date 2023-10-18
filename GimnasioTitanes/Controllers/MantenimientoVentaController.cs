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
    public class MantenimientoVentaController : Controller
    {
        private bd_titanesGymEntities db = new bd_titanesGymEntities();

        // GET: MantenimientoVenta
        public ActionResult Index()
        {
            var venta = db.venta.Include(v => v.planes).Include(v => v.usuario);
            return View(venta.ToList());
        }

        // GET: MantenimientoVenta/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            venta venta = db.venta.Find(id);
            if (venta == null)
            {
                return HttpNotFound();
            }
            return View(venta);
        }

        // GET: MantenimientoVenta/Create
        public ActionResult Create()
        {
            ViewBag.id_planes = new SelectList(db.planes, "id_planes", "plan_nombre");
            ViewBag.rut_usuario = new SelectList(db.usuario, "rut_usuario", "usu_nombre");
            return View();
        }

        // POST: MantenimientoVenta/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_venta,fecha_venta,rut_usuario,id_planes,cantidad_venta,valor_venta")] venta venta)
        {
            if (ModelState.IsValid)
            {
                db.venta.Add(venta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_planes = new SelectList(db.planes, "id_planes", "plan_nombre", venta.id_planes);
            ViewBag.rut_usuario = new SelectList(db.usuario, "rut_usuario", "usu_nombre", venta.rut_usuario);
            return View(venta);
        }

        // GET: MantenimientoVenta/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            venta venta = db.venta.Find(id);
            if (venta == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_planes = new SelectList(db.planes, "id_planes", "plan_nombre", venta.id_planes);
            ViewBag.rut_usuario = new SelectList(db.usuario, "rut_usuario", "usu_nombre", venta.rut_usuario);
            return View(venta);
        }

        // POST: MantenimientoVenta/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_venta,fecha_venta,rut_usuario,id_planes,cantidad_venta,valor_venta")] venta venta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(venta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_planes = new SelectList(db.planes, "id_planes", "plan_nombre", venta.id_planes);
            ViewBag.rut_usuario = new SelectList(db.usuario, "rut_usuario", "usu_nombre", venta.rut_usuario);
            return View(venta);
        }

        // GET: MantenimientoVenta/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            venta venta = db.venta.Find(id);
            if (venta == null)
            {
                return HttpNotFound();
            }
            return View(venta);
        }

        // POST: MantenimientoVenta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            venta venta = db.venta.Find(id);
            db.venta.Remove(venta);
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
