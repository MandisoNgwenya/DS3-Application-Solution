using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Application.ClientUI.Models;

namespace Application.ClientUI.Controllers
{
    public class TechnicianController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Technician
        public ActionResult Index()
        {
            return View(db.TechnicianModels.ToList());
        }

        // GET: Technician/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TechnicianModel technicianModel = db.TechnicianModels.Find(id);
            if (technicianModel == null)
            {
                return HttpNotFound();
            }
            return View(technicianModel);
        }

        // GET: Technician/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Technician/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,name")] TechnicianModel technicianModel)
        {
            if (ModelState.IsValid)
            {
                db.TechnicianModels.Add(technicianModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(technicianModel);
        }

        // GET: Technician/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TechnicianModel technicianModel = db.TechnicianModels.Find(id);
            if (technicianModel == null)
            {
                return HttpNotFound();
            }
            return View(technicianModel);
        }

        // POST: Technician/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,name")] TechnicianModel technicianModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(technicianModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(technicianModel);
        }

        // GET: Technician/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TechnicianModel technicianModel = db.TechnicianModels.Find(id);
            if (technicianModel == null)
            {
                return HttpNotFound();
            }
            return View(technicianModel);
        }

        // POST: Technician/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TechnicianModel technicianModel = db.TechnicianModels.Find(id);
            db.TechnicianModels.Remove(technicianModel);
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
