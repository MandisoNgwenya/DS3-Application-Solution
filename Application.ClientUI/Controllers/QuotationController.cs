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
    public class QuotationController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Devices(string searchString)
        {
            string Search = searchString;
            try
            {
                var devices = from m in db.DeviceModels
                              select m;

                if (!String.IsNullOrEmpty(searchString))
                {
                    devices = devices.Where(s => s.customerIdNumber.Contains(searchString));
                }
                return View(devices);
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }


        public ActionResult AllocateTechnician() { 

            
            var courseList = new List<SelectListItem>();
        var courseQuery = from c in db.TechnicianModels select c;
            foreach (var m in courseQuery)
            {
                courseList.Add(new SelectListItem
                {
                    Value = m.name
                    ,
                    Text = m.name
    });
                ViewBag.CoursesList = courseList;

            }
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
                TempData["SerialNumber"] = model.serialNo;
                TempData["datein"] = model.datein;
                TempData["dateout"] = model.dateout;
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

            //double bal = Convert.ToDouble(TempData["Balance"]);

            //bal = deviceModel.Total - deviceModel.Deposit;
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
            TempData["Status"] = deviceModel.status;
            TempData["IdentityNumber"] = deviceModel.customerIdNumber;

            TempData["Technician"] = deviceModel.technician;
            if (ModelState.IsValid)
            {
            
                var device = new DeviceModel();

                device.technician = deviceModel.technician;
                device.datein = deviceModel.datein;
                device.dateout = deviceModel.dateout;
                device.status = deviceModel.status;
                device.Accessories = deviceModel.Accessories;
                device.Description = deviceModel.Description;
                device.Total = deviceModel.Total;
                device.Deposit = deviceModel.Deposit;
                //device.Balance = Convert.ToDouble(TempData["Balance"].ToString());
                db.Entry(deviceModel).State = EntityState.Modified;


                TempData["status"] = deviceModel.status;
                TempData["IdentityNumber"] = deviceModel.customerIdNumber;
                TempData["SerialNumber"] = deviceModel.serialNo;
                TempData["datein"] = deviceModel.datein;
                TempData["dateout"] = deviceModel.dateout;
                TempData["technician"] = deviceModel.technician;
                TempData["Ass"] = deviceModel.Accessories;
                TempData["Desc"] = deviceModel.Description;
                //quote.IdentityNumber = TempData["IdentityNumber"].ToString();
                //quote.Job_Card = TempData["Session"].ToString();
                //quote.Name = TempData["Name"].ToString();
                //quote.Status = TempData["Status"].ToString();
                //quote.technician = TempData["Technician"].ToString();
                db.SaveChanges();
                //return RedirectToAction("Finish" new );



                return RedirectToAction("Quotes", "Devices", new
                {

                    technician = deviceModel.technician,
                    datein = deviceModel.datein,
                    dateout = deviceModel.dateout,
                    status = deviceModel.status,
                    id = deviceModel.customerIdNumber,
                    dec = deviceModel.Description,
                    acc = deviceModel.Accessories,



          
                });
            }
            return View(deviceModel);
        }

        public ActionResult Finish(QuotationModel model,DeviceModel m  ,string sNum,string IDnum)
        {
            TempData.Keep();
            //model.Name = TempData["SerialNumber"].ToString();
            //model.Status = TempData["status"].ToString();

            model.IdentityNumber = sNum;
            //quote.technician = TempData["technician"].ToString();
            //quote.IdentityNumber = TempData["IdentityNumber"].ToString();

            //m.customerIdNumber = TempData["IdentityNumber"].ToString();




            return View();
        }   

        [HttpPost]
        public ActionResult Finish([Bind(Include = "Id,Job_Card,Name,IdentityNumber,Description,Deposit,Total,Balance,technician,Accessories,Status,email")] QuotationModel model)
        {
            TempData.Keep();
            if (ModelState.IsValid)
            {
                double balance = model.Total - model.Deposit;
                model.Balance = balance;

                var quote = new QuotationModel();

                quote.Accessories = model.Accessories;
                quote.Balance = balance;
                quote.Deposit = model.Deposit;
                quote.Description = model.Description;
                //quote.IdentityNumber = TempData["IdentityNumber"].ToString();
                ////quote.Job_Card = TempData["Session"].ToString();
                quote.Name = TempData["SerialNumber"].ToString();
                quote.Status = TempData["status"].ToString();
                quote.technician = TempData["technician"].ToString();
                quote.IdentityNumber = TempData["IdentityNumber"].ToString();
                quote.Accessories = TempData["Ass"].ToString();
                quote.Description = TempData["Desc"].ToString();

                quote.Total = model.Total;

                db.QuotationModels.Add(quote);
                db.SaveChanges();

                //TempData["status"] = deviceModel.status;
                //TempData["IdentityNumber"] = deviceModel.customerIdNumber;
                //TempData["SerialNumber"] = deviceModel.serialNo;
                //TempData["datein"] = deviceModel.datein;
                //TempData["dateout"] = deviceModel.dateout;
                //TempData["technician"] = deviceModel.technician;


            }


          return  RedirectToAction("Index");
        }

        public ActionResult Confirm()
        {
            return View();
        }

        //var device = new DeviceModel();

        //device.technician = model.technician;
        //        device.datein = model.datein;
        //        device.dateout = model.dateout;
        //        device.status = model.status;


        //        TempData["status"] = model.status;
        //        TempData["IdentityNumber"] = model.customerIdNumber;

              
        //        TempData["technician"] = model.technician;
        //        db.DeviceModels.Add(device);
        //        db.SaveChanges();

              
        //        //Session["SerialNumber"] = model.serialNo.ToString();
        //        return RedirectToAction("NewQuote");


    

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
