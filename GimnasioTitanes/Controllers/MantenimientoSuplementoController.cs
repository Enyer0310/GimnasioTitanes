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
    public class MantenimientoSuplementoController : Controller
    {
        private bd_titanesGymEntities db = new bd_titanesGymEntities();

        // GET: MantenimientoSuplemento
        public ActionResult Index()
        {
            return View(db.suplemento.ToList());
        }

        // GET: MantenimientoSuplemento/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            suplemento suplemento = db.suplemento.Find(id);
            if (suplemento == null)
            {
                return HttpNotFound();
            }
            return View(suplemento);
        }

        // GET: MantenimientoSuplemento/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MantenimientoSuplemento/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_suplemento,nom_suplemento")] suplemento suplemento)
        {
            if (ModelState.IsValid)
            {
                db.suplemento.Add(suplemento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(suplemento);
        }

        // GET: MantenimientoSuplemento/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            suplemento suplemento = db.suplemento.Find(id);
            if (suplemento == null)
            {
                return HttpNotFound();
            }
            return View(suplemento);
        }

        // POST: MantenimientoSuplemento/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_suplemento,nom_suplemento")] suplemento suplemento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(suplemento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(suplemento);
        }

        // GET: MantenimientoSuplemento/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            suplemento suplemento = db.suplemento.Find(id);
            if (suplemento == null)
            {
                return HttpNotFound();
            }
            return View(suplemento);
        }

        // POST: MantenimientoSuplemento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            suplemento suplemento = db.suplemento.Find(id);
            db.suplemento.Remove(suplemento);
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
