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
    public class MantenimientoProveedorMaquinasController : Controller
    {
        private bd_titanesGymEntities db = new bd_titanesGymEntities();

        // GET: MantenimientoProveedorMaquinas
        public ActionResult Index()
        {
            return View(db.proveedorMaquinas.ToList());
        }

        // GET: MantenimientoProveedorMaquinas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            proveedorMaquinas proveedorMaquinas = db.proveedorMaquinas.Find(id);
            if (proveedorMaquinas == null)
            {
                return HttpNotFound();
            }
            return View(proveedorMaquinas);
        }

        // GET: MantenimientoProveedorMaquinas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MantenimientoProveedorMaquinas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_proveedorMaquinas,nom_maquina")] proveedorMaquinas proveedorMaquinas)
        {
            if (ModelState.IsValid)
            {
                db.proveedorMaquinas.Add(proveedorMaquinas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(proveedorMaquinas);
        }

        // GET: MantenimientoProveedorMaquinas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            proveedorMaquinas proveedorMaquinas = db.proveedorMaquinas.Find(id);
            if (proveedorMaquinas == null)
            {
                return HttpNotFound();
            }
            return View(proveedorMaquinas);
        }

        // POST: MantenimientoProveedorMaquinas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_proveedorMaquinas,nom_maquina")] proveedorMaquinas proveedorMaquinas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(proveedorMaquinas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(proveedorMaquinas);
        }

        // GET: MantenimientoProveedorMaquinas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            proveedorMaquinas proveedorMaquinas = db.proveedorMaquinas.Find(id);
            if (proveedorMaquinas == null)
            {
                return HttpNotFound();
            }
            return View(proveedorMaquinas);
        }

        // POST: MantenimientoProveedorMaquinas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            proveedorMaquinas proveedorMaquinas = db.proveedorMaquinas.Find(id);
            db.proveedorMaquinas.Remove(proveedorMaquinas);
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
