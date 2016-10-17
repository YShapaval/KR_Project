using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KursProject.Models;
using test.Models;

namespace KursProject.Controllers
{
    public class KafedrasController : Controller
    {
        private KursProjectContext db = new KursProjectContext();

        // GET: Kafedras
        public ActionResult Index()
        {
            var kafedra = db.Kafedras.Include(s => s.Facult);
            return View(kafedra.ToList());
        }

        // GET: Kafedras/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kafedra kafedra = db.Kafedras.Find(id);
            if (kafedra == null)
            {
                return HttpNotFound();
            }
            return View(kafedra);
        }

        // GET: Kafedras/Create
        public ActionResult Create()
        {
            ViewBag.FacultID = new SelectList(db.Facults, "FacultID", "Name");
            return View();
        }

        // POST: Kafedras/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "KafedraID,Name,FacultID")] Kafedra kafedra)
        {
            if (ModelState.IsValid)
            {
                db.Kafedras.Add(kafedra);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FacultID = new SelectList(db.Facults, "FacultID", "Name",kafedra.FacultID);
            return View(kafedra);
        }

        // GET: Kafedras/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kafedra kafedra = db.Kafedras.Find(id);
            if (kafedra == null)
            {
                return HttpNotFound();
            }
            return View(kafedra);
        }

        // POST: Kafedras/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "KafedraID,Name,FacultID")] Kafedra kafedra)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kafedra).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kafedra);
        }

        // GET: Kafedras/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kafedra kafedra = db.Kafedras.Find(id);
            if (kafedra == null)
            {
                return HttpNotFound();
            }
            return View(kafedra);
        }

        // POST: Kafedras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Kafedra kafedra = db.Kafedras.Find(id);
            db.Kafedras.Remove(kafedra);
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
