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
    public class MantenimientoProveedorSuplementoController : Controller
    {
        private bd_titanesGymEntities db = new bd_titanesGymEntities();

        // GET: MantenimientoProveedorSuplemento
        public ActionResult Index()
        {
            return View(db.proveedorSuplemento.ToList());
        }

        // GET: MantenimientoProveedorSuplemento/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            proveedorSuplemento proveedorSuplemento = db.proveedorSuplemento.Find(id);
            if (proveedorSuplemento == null)
            {
                return HttpNotFound();
            }
            return View(proveedorSuplemento);
        }

        // GET: MantenimientoProveedorSuplemento/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MantenimientoProveedorSuplemento/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_proveedorSuplemento,nom_proveedor")] proveedorSuplemento proveedorSuplemento)
        {
            if (ModelState.IsValid)
            {
                db.proveedorSuplemento.Add(proveedorSuplemento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(proveedorSuplemento);
        }

        // GET: MantenimientoProveedorSuplemento/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            proveedorSuplemento proveedorSuplemento = db.proveedorSuplemento.Find(id);
            if (proveedorSuplemento == null)
            {
                return HttpNotFound();
            }
            return View(proveedorSuplemento);
        }

        // POST: MantenimientoProveedorSuplemento/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_proveedorSuplemento,nom_proveedor")] proveedorSuplemento proveedorSuplemento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(proveedorSuplemento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(proveedorSuplemento);
        }

        // GET: MantenimientoProveedorSuplemento/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            proveedorSuplemento proveedorSuplemento = db.proveedorSuplemento.Find(id);
            if (proveedorSuplemento == null)
            {
                return HttpNotFound();
            }
            return View(proveedorSuplemento);
        }

        // POST: MantenimientoProveedorSuplemento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            proveedorSuplemento proveedorSuplemento = db.proveedorSuplemento.Find(id);
            db.proveedorSuplemento.Remove(proveedorSuplemento);
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
