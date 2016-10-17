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
    public class PrepodsController : Controller
    {
        private KursProjectContext db = new KursProjectContext();

        // GET: Prepods
        public ActionResult Index()
        {
            var prepods = db.Prepods.Include(p => p.Kafedri);
            return View(prepods.ToList());
        }

        // GET: Prepods/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prepod prepod = db.Prepods.Find(id);
            if (prepod == null)
            {
                return HttpNotFound();
            }
            return View(prepod);
        }

        // GET: Prepods/Create
        public ActionResult Create()
        {
            ViewBag.KafedraID = new SelectList(db.Kafedras, "KafedraID", "Name");
            return View();
        }

        // POST: Prepods/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PrepodID,Name,Dolznost,Vozrast,KafedraID")] Prepod prepod)
        {
            if (ModelState.IsValid)
            {
                db.Prepods.Add(prepod);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.KafedraID = new SelectList(db.Kafedras, "KafedraID", "Name", prepod.KafedraID);
            return View(prepod);
        }

        // GET: Prepods/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prepod prepod = db.Prepods.Find(id);
            if (prepod == null)
            {
                return HttpNotFound();
            }
            ViewBag.KafedraID = new SelectList(db.Kafedras, "KafedraID", "Name", prepod.KafedraID);
            return View(prepod);
        }

        // POST: Prepods/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PrepodID,Name,Dolznost,Vozrast,KafedraID")] Prepod prepod)
        {
            if (ModelState.IsValid)
            {
                db.Entry(prepod).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.KafedraID = new SelectList(db.Kafedras, "KafedraID", "Name", prepod.KafedraID);
            return View(prepod);
        }

        // GET: Prepods/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prepod prepod = db.Prepods.Find(id);
            if (prepod == null)
            {
                return HttpNotFound();
            }
            return View(prepod);
        }

        // POST: Prepods/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Prepod prepod = db.Prepods.Find(id);
            db.Prepods.Remove(prepod);
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
