using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KursProject.Models;

namespace KursProject.Controllers
{
    public class FacultsController : Controller
    {
        private KursProjectContext db = new KursProjectContext();

        // GET: Facults
        public ActionResult Index()
        {
            return View(db.Facults.ToList());
        }

        // GET: Facults/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Facult facult = db.Facults.Find(id);
            if (facult == null)
            {
                return HttpNotFound();
            }
            return View(facult);
        }

        // GET: Facults/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Facults/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FacultID,Name")] Facult facult)
        {
            if (ModelState.IsValid)
            {
                db.Facults.Add(facult);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(facult);
        }

        // GET: Facults/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Facult facult = db.Facults.Find(id);
            if (facult == null)
            {
                return HttpNotFound();
            }
            return View(facult);
        }

        // POST: Facults/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FacultID,Name")] Facult facult)
        {
            if (ModelState.IsValid)
            {
                db.Entry(facult).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(facult);
        }

        // GET: Facults/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Facult facult = db.Facults.Find(id);
            if (facult == null)
            {
                return HttpNotFound();
            }
            return View(facult);
        }

        // POST: Facults/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Facult facult = db.Facults.Find(id);
            db.Facults.Remove(facult);
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
