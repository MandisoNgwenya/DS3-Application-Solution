using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Application.ClientUI.Models;
using Microsoft.AspNet.Identity;

namespace Application.ClientUI.Controllers
{
    public class ProfileController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();


        public ActionResult Home()
        {
            return View();
        }
        public ActionResult myBookings()
        {
            //string userID = User.Identity.GetUserId();
            //return View(db.BookingViewModels.Where(x => x.Id == userID));
            return View(db.BookingViewModels.ToList());
        }

        public ActionResult QuotationsProfile()
        {

            string s = "";
            //Session["TempID"] = db.QuotationModels.Where(x => x.IdentityNumber.Contains(string s));  
            Session["TempID"] = db.Users.Where(x => x.IdentityNumber.Contains(s));
            string ID = Session["TempID"].ToString();

            return View();
            //string ID = User.Identity.GetUserName(
            //string u = User.Identity.Name

            //return View(db.QuotationModels.Where(x => x.IdentityNumber == ID).ToString());



        }

        public ActionResult myDevices()
        {
            return View();


        }
        public ActionResult Index()
        {
            //var profiles = db.Profiles.Include(p => p.ApplicationUser);
            return View(db.Profiles.ToList());
            //return View();
        }
    }
}

//GET: ProfileModels


//        // GET: ProfileModels/Details/5
//        public ActionResult Details(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            ProfileModel profileModel = db.Profiles.Find(id);
//            if (profileModel == null)
//            {
//                return HttpNotFound();
//            }
//            return View(profileModel);
//        }

//        // GET: ProfileModels/Create
//        public ActionResult Create()
//        {
//            ViewBag.Id = new SelectList(db.ApplicationUsers, "Id", "Title");
//            return View();
//        }

//        // POST: ProfileModels/Create
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Create([Bind(Include = "profileID,Name,Surname,IdentityNumber,Address,CellNo,Date,Clerk,Technician,JobCard,Title,Country,Province,AreaCode,DateOfBirth,SerialNo,Email,DeviceName,type,datein,dateout,status,Id,deviceID")] ProfileModel profileModel)
//        {
//            if (ModelState.IsValid)
//            {
//                db.Profiles.Add(profileModel);
//                db.SaveChanges();
//                return RedirectToAction("Index");
//            }

//            ViewBag.Id = new SelectList(db.ApplicationUsers, "Id", "Title", profileModel.Id);
//            return View(profileModel);
//        }

//        // GET: ProfileModels/Edit/5
//        public ActionResult Edit(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            ProfileModel profileModel = db.Profiles.Find(id);
//            if (profileModel == null)
//            {
//                return HttpNotFound();
//            }
//            ViewBag.Id = new SelectList(db.ApplicationUsers, "Id", "Title", profileModel.Id);
//            return View(profileModel);
//        }

//        // POST: ProfileModels/Edit/5
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Edit([Bind(Include = "profileID,Name,Surname,IdentityNumber,Address,CellNo,Date,Clerk,Technician,JobCard,Title,Country,Province,AreaCode,DateOfBirth,SerialNo,Email,DeviceName,type,datein,dateout,status,Id,deviceID")] ProfileModel profileModel)
//        {
//            if (ModelState.IsValid)
//            {
//                db.Entry(profileModel).State = EntityState.Modified;
//                db.SaveChanges();
//                return RedirectToAction("Index");
//            }
//            ViewBag.Id = new SelectList(db.ApplicationUsers, "Id", "Title", profileModel.Id);
//            return View(profileModel);
//        }

//        // GET: ProfileModels/Delete/5
//        public ActionResult Delete(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            ProfileModel profileModel = db.Profiles.Find(id);
//            if (profileModel == null)
//            {
//                return HttpNotFound();
//            }
//            return View(profileModel);
//        }

//        // POST: ProfileModels/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public ActionResult DeleteConfirmed(int id)
//        {
//            ProfileModel profileModel = db.Profiles.Find(id);
//            db.Profiles.Remove(profileModel);
//            db.SaveChanges();
//            return RedirectToAction("Index");
//        }

//        protected override void Dispose(bool disposing)
//        {
//            if (disposing)
//            {
//                db.Dispose();
//            }
//            base.Dispose(disposing);
//        }
//    }
//}
