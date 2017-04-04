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
    public class QuotationController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Devices()
        {
            return View(db.DeviceModels.ToList());
        }


        public ActionResult AllocateTechnician()
        {
            return View();
        }
     [HttpPost]

    
        public ActionResult AllocateTechnician([Bind(Include = "id,serialNo,technician,customerIdNumber,DeviceName,type,Devicemodel,datein,dateout,status")] DeviceModel model)
        {
            TempData.Keep();

            
            if (ModelState.IsValid)



            {
                var device = new DeviceModel();

                device.technician = model.technician;
                device.datein = model.datein;
                device.dateout = model.dateout;
                device.status = model.status;


                TempData["status"] = model.status;
                TempData["IdentityNumber"] = model.customerIdNumber;

              
                TempData["technician"] = model.technician;
                db.DeviceModels.Add(device);
                db.SaveChanges();

              
                //Session["SerialNumber"] = model.serialNo.ToString();
                return RedirectToAction("NewQuote");


            }



            return View(model);

        }

        // GET: QuotationModels
        public ActionResult Index()
        {


            return View(db.QuotationModels.ToList());
        }

        // GET: QuotationModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuotationModel quotationModel = db.QuotationModels.Find(id);
            if (quotationModel == null)
            {
                return HttpNotFound();
            }
            return View(quotationModel);
        }

        // GET: QuotationModels/Create
        public ActionResult Create()
        {
            return View();
        }

 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Job_Card,Name,IdentityNumber,Description,Deposit,Total,Balance,technician,Accessories,Status,email")] QuotationModel quotationModel)
        {
            TempData.Keep();
            if (ModelState.IsValid)
            {
                //quotationModel.technician = TempData["technician"].ToString();

                var q = new QuotationModel();
                TempData["technician"] = quotationModel.technician;
                //TempData["technician"] = quotationModel.technician;
                db.QuotationModels.Add(q);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(quotationModel);
        }


        public ActionResult NewQuote(int? id)
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


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NewQuote ([Bind(Include = "id,serialNo,technician,customerIdNumber,DeviceName,type,Devicemodel,datein,dateout,status")] DeviceModel deviceModel)
        {
            if (ModelState.IsValid)
            {
                var device = new DeviceModel();

                device.technician = deviceModel.technician;
                device.datein = deviceModel.datein;
                device.dateout = deviceModel.dateout;
                device.status = deviceModel.status;
                db.Entry(deviceModel).State = EntityState.Modified;

                TempData["status"] = deviceModel.status;
                TempData["IdentityNumber"] = deviceModel.customerIdNumber;
               
                TempData["technician"] = deviceModel.technician;
                db.SaveChanges();
                return RedirectToAction("Finish");
            }
            return View(deviceModel);
        }

        public ActionResult Finish(QuotationModel model,DeviceModel m  )
        {

            m.customerIdNumber = TempData["IdentityNumber"].ToString();
            double balance = model.Total - model.Deposit;
            model.Balance = balance;




            return View(db.Bookings.ToList());
        }

        [HttpPost]
        public ActionResult Finish([Bind(Include = "Id,Job_Card,Name,IdentityNumber,Description,Deposit,Total,Balance,technician,Accessories,Status,email")] QuotationModel model)
        {
            if (ModelState.IsValid)
            {

            
            var quotation = new QuotationModel();
                TempData["status"] = model.Status;
                TempData["IdentityNumber"] = model.IdentityNumber;  
                TempData["technician"] = model.technician;
            }


            return View();
        }

    

    public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuotationModel quotationModel = db.QuotationModels.Find(id);
            if (quotationModel == null)
            {
                return HttpNotFound();
            }
            return View(quotationModel);
        }

        // POST: QuotationModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            QuotationModel quotationModel = db.QuotationModels.Find(id);
            db.QuotationModels.Remove(quotationModel);
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
