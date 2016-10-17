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
    public class StudyProcessesController : Controller
    {
        private KursProjectContext db = new KursProjectContext();

        // GET: StudyProcesses
        public ActionResult Index()
        {
            var studyProcesses = db.StudyProcesses.Include(s => s.Kafedra).Include(s => s.Speciality);
            return View(studyProcesses.ToList());
        }

        // GET: StudyProcesses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudyProcess studyProcess = db.StudyProcesses.Find(id);
            if (studyProcess == null)
            {
                return HttpNotFound();
            }
            return View(studyProcess);
        }

        // GET: StudyProcesses/Create
        public ActionResult Create()
        {
            ViewBag.KafedraID = new SelectList(db.Kafedras, "KafedraID", "Name");
            ViewBag.SpecialityID = new SelectList(db.Specialities, "SpecialityID", "Name");
            return View();
        }

        // POST: StudyProcesses/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StudyProcessID,KafedraID,SpecialityID,Date")] StudyProcess studyProcess)
        {
            if (ModelState.IsValid)
            {
                db.StudyProcesses.Add(studyProcess);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.KafedraID = new SelectList(db.Kafedras, "KafedraID", "Name", studyProcess.KafedraID);
            ViewBag.SpecialityID = new SelectList(db.Specialities, "SpecialityID", "Name", studyProcess.SpecialityID);
            return View(studyProcess);
        }

        // GET: StudyProcesses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudyProcess studyProcess = db.StudyProcesses.Find(id);
            if (studyProcess == null)
            {
                return HttpNotFound();
            }
            ViewBag.KafedraID = new SelectList(db.Kafedras, "KafedraID", "Name", studyProcess.KafedraID);
            ViewBag.SpecialityID = new SelectList(db.Specialities, "SpecialityID", "Name", studyProcess.SpecialityID);
            return View(studyProcess);
        }

        // POST: StudyProcesses/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StudyProcessID,KafedraID,SpecialityID,Date")] StudyProcess studyProcess)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studyProcess).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.KafedraID = new SelectList(db.Kafedras, "KafedraID", "Name", studyProcess.KafedraID);
            ViewBag.SpecialityID = new SelectList(db.Specialities, "SpecialityID", "Name", studyProcess.SpecialityID);
            return View(studyProcess);
        }

        // GET: StudyProcesses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudyProcess studyProcess = db.StudyProcesses.Find(id);
            if (studyProcess == null)
            {
                return HttpNotFound();
            }
            return View(studyProcess);
        }

        // POST: StudyProcesses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StudyProcess studyProcess = db.StudyProcesses.Find(id);
            db.StudyProcesses.Remove(studyProcess);
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
