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
    [Authorize]
    public class DevicesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Devices
        public ActionResult Quotes()
        {
            return View(db.DeviceModels.ToList());
        }

        // GET: Devices/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeviceModel deviceModel = db.DeviceModels.Find(id);
            if (deviceModel == null)
            {
                return HttpNotFound();
            }
            return View(deviceModel);
        }

        // GET: Devices/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Devices/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,serialNo,technician,customerIdNumber,DeviceName,type,datein,dateout,status,Accessories,Description,Deposit,Total,Balance")] DeviceModel deviceModel)
        {
            if (ModelState.IsValid)
            {
                db.DeviceModels.Add(deviceModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(deviceModel);
        }

        // GET: Devices/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeviceModel deviceModel = db.DeviceModels.Find(id);
            if (deviceModel == null)
            {
                return HttpNotFound();
            }
            return View(deviceModel);
        }

        // POST: Devices/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,serialNo,technician,customerIdNumber,DeviceName,type,datein,dateout,status,Accessories,Description,Deposit,Total,Balance")] DeviceModel deviceModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(deviceModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(deviceModel);
        }

        // GET: Devices/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeviceModel deviceModel = db.DeviceModels.Find(id);
            if (deviceModel == null)
            {
                return HttpNotFound();
            }
            return View(deviceModel);
        }

        // POST: Devices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DeviceModel deviceModel = db.DeviceModels.Find(id);
            db.DeviceModels.Remove(deviceModel);
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
