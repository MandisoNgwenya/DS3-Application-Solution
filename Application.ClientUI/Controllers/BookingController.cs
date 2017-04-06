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
using Microsoft.AspNet.Identity.EntityFramework;

namespace Application.ClientUI.Controllers
{
    [Authorize]
    public class BookingController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();


        public ActionResult Index(string searchString)
        {
            string Search = searchString;
            try
            {
                var bookings = from m in db.BookingViewModels
                              select m;

                if (!String.IsNullOrEmpty(searchString))
                {
                   bookings = bookings.Where(s => s.SerialNo.Contains(searchString));
                }
                return View(bookings);
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }
        public ActionResult Wizard(string name, string surname, string n, string IdentityNumber, string title, string address, string country,
            string province, string areacode, string cellno, string dob, string email)
        {
            try
            {

                Random gen = new Random();

                int size = 10;
                string input = "abcdefghijklmnopqrstuvwxyz0123456789";
                char[] chars = new char[size];
                for (int i = 0; i < size; i++)
                {
                    chars[i] = input[gen.Next(input.Length)];
                }

                BookingViewModel b = new BookingViewModel();



                //UserName = model.Email,
                //    Email = model.Email,







                //    CellNo = model.CellNo,
                //    DateOfBirth = model.DateOfBirth
                b.Name = name;
                b.Surname = surname;
                b.IdentityNumber = IdentityNumber;
                b.JobCard = chars.ToString();
                b.Title = title;
                b.Address = address;
                b.Country = country;
                b.Province = province;
                b.AreaCode = areacode;
                b.CellNo = cellno;
                b.DateOfBirth = dob;
                b.Email = email;
                b.Id = User.Identity.GetUserId();
                UserManager<ApplicationUser> UserManager =
                    new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
                b.Id = UserManager.FindById(User.Identity.GetUserId()).ToString();
                return View(b);
            }
            catch
            {
                return RedirectToAction("Register", "Account");
            }


        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Wizard(string BtnEdit, [Bind(Include = "BookingID,Name,Surname,IdentityNumber,Address,CellNo,Device,Date,Clerk,Technician,JobCard,Title,Country,Province,AreaCode,DateOfBirth,Model,SerialNo,Signature,Email,Id")] BookingViewModel model)
        {

            //BookingID,cName,cSurname,IDNumber,Address,TelNo,Device,Date,Clerk,Technician,JobCard,Id
            Random gen = new Random();

            int size = 10;
            string input = "abcdefghijklmnopqrstuvwxyz0123456789";
            char[] chars = new char[size];
            for (int i = 0; i <size; i++)
            {
                chars[i] = input[gen.Next(input.Length)];
            }
            model.JobCard = chars.ToString();

            //long idNo = Convert.ToInt32(model.IDNumber);
            //if (idNo <= 0 && idNo >= 14)
            //{
            //    ViewBag.Error = "Invalid Identity Number";
            //}

            if (BtnEdit != null)

            {

                Session["Name"] = model.Name;
                TempData["Surname"] = model.Surname;

                TempData["JobCard"] = model.JobCard;
                Session["IdentityNumber"] = model.IdentityNumber;
                TempData["CellNo"] = model.CellNo;
                TempData["Address"] = model.Address;
                TempData["Device"] = model.Device;
                TempData["Country"] = model.Country;

                TempData["AreaCode"] = model.AreaCode;
                TempData["Province"] = model.Province;
                TempData["Email"] = model.Email;
                TempData["Date"] = model.Surname;
                TempData["DateOfBirth"] = model.Name;
                TempData["Surname"] = model.Surname;
                TempData["UserID"] = model.Id;

            }
            if (ModelState.IsValid)



            {

                var booking = new BookingViewModel();



                booking.JobCard = model.JobCard; booking.Name = model.Name; booking.Surname = model.Surname;
                booking.IdentityNumber = model.IdentityNumber; booking.JobCard = model.JobCard; booking.CellNo = model.CellNo;
                booking.Address = model.Address; booking.Device = model.Device; booking.Country = model.Country;
                booking.Address = model.Address;
                booking.AreaCode = model.AreaCode;
                booking.Date = model.Date;
                booking.Email = model.Email;
                booking.Province = model.Province;
                booking.Title = model.Title;
                booking.DateOfBirth = model.DateOfBirth;
                booking.SerialNo = model.SerialNo;
                booking.Id = User.Identity.GetUserId();

                Session["Name"] = model.Name;
                TempData["Surname"] = model.Surname;
                TempData["SerialNumber"] = model.SerialNo;
                TempData["JobCard"] = model.JobCard;
                Session["IdentityNumber"] = model.IdentityNumber;
                TempData["CellNo"] = model.CellNo;
                TempData["Address"] = model.Address;
                TempData["Device"] = model.Device;
                TempData["Country"] = model.Country;

                TempData["AreaCode"] = model.AreaCode;
                TempData["Province"] = model.Province;
                TempData["Email"] = model.Email;
                TempData["Date"] = model.Surname;
                TempData["DateOfBirth"] = model.Name;
                TempData["Surname"] = model.Surname;
                TempData["UserID"] = model.Id;

                db.BookingViewModels.Add(booking);
                db.SaveChanges();

                return RedirectToAction("Device");



            }

            return View(model);
        }

        public ActionResult EditDetails(string name, string surname, string n, string IdentityNumber, string title, string address, string country,
            string province, string areacode, string cellno, string dob, string email)
        {


            TempData.Keep();
           
                TempData.Keep();
                Random gen = new Random();

                int size = 10;
                string input = "abcdefghijklmnopqrstuvwxyz0123456789";
                char[] chars = new char[size];
                for (int i = 0; i < size; i++)
                {
                    chars[i] = input[gen.Next(input.Length)];
                }

                BookingViewModel b = new BookingViewModel();



                //UserName = model.Email,
                //    Email = model.Email,







                //    CellNo = model.CellNo,
                //    DateOfBirth = model.DateOfBirth
                b.Name = name;
                b.Surname = surname;
                b.IdentityNumber = IdentityNumber;
                b.JobCard = chars.ToString();
                b.Title = title;
                b.Address = address;
                b.Country = country;
                b.Province = province;
                b.AreaCode = areacode;
                b.CellNo = cellno;
                b.DateOfBirth = dob;
                b.Email = email;

                b.Id = User.Identity.GetUserId();
                UserManager<ApplicationUser> UserManager =
                    new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
                b.Id = UserManager.FindById(User.Identity.GetUserId()).ToString();
                return View(b);
          


        }
        [HttpPost]
        public ActionResult EditDetails(BookingViewModel model)
        {


            if (ModelState.IsValid)
            {
                var booking = new BookingViewModel();



                booking.JobCard = model.JobCard; booking.Name = model.Name; booking.Surname = model.Surname;
                booking.IdentityNumber = model.IdentityNumber; booking.JobCard = model.JobCard; booking.CellNo = model.CellNo;
                booking.Address = model.Address; booking.Device = model.Device; booking.Country = model.Country;
                booking.Address = model.Address;
                booking.AreaCode = model.AreaCode;
                booking.Date = model.Date;
                booking.Email = model.Email;
                booking.Province = model.Province;
                booking.Title = model.Title;
                booking.DateOfBirth = model.DateOfBirth;
                booking.Id = User.Identity.GetUserId();

                Session["Name"] = model.Name;
                TempData["Surname"] = model.Surname;

                TempData["JobCard"] = model.JobCard;
                Session["IdentityNumber"] = model.IdentityNumber;
                TempData["CellNo"] = model.CellNo;
                TempData["Address"] = model.Address;
                TempData["Device"] = model.Device;
                TempData["Country"] = model.Country;

                TempData["AreaCode"] = model.AreaCode;
                TempData["Province"] = model.Province;
                TempData["Email"] = model.Email;
                TempData["Date"] = model.Surname;
                TempData["DateOfBirth"] = model.Name;
                TempData["Surname"] = model.Surname;
                TempData["UserID"] = model.Id;

                db.BookingViewModels.Add(booking);
                db.SaveChanges();

                return View();

            }
            return View(model);
        }
        public ActionResult Device()
        {


            TempData.Keep();

            return View();

        }
        [HttpPost]
        public ActionResult Device([Bind(Include = "id,serialNo,technician,customerIdNumber,DeviceName,type,Devicemodel,datein,dateout,status")] DeviceModel model)
        {
            TempData.Keep();
            if (ModelState.IsValid)



            {
                var device = new DeviceModel();

                device.DeviceName = model.DeviceName;
                device.serialNo = model.serialNo;
                device.type = model.type;


                device.customerIdNumber = Session["IdentityNumber"].ToString();
                db.DeviceModels.Add(device);
                db.SaveChanges();

                return RedirectToAction("Home","Profile" );


            }



            return View(model);

        }



        public ActionResult Bookings( BookingViewModel model)
        {


            Session["Name"] = model.Name;
            TempData["Surname"] = model.Surname;

            TempData["JobCard"] = model.JobCard;
            Session["IdentityNumber"] = model.IdentityNumber;
            TempData["CellNo"] = model.CellNo;
            TempData["Address"] = model.Address;
            TempData["Device"] = model.Device;
            TempData["Country"] = model.Country;

            TempData["AreaCode"] = model.AreaCode;
            TempData["Province"] = model.Province;
            TempData["Email"] = model.Email;
            TempData["Date"] = model.Surname;
            TempData["DateOfBirth"] = model.Name;
            TempData["Surname"] = model.Surname;
            TempData["UserID"] = model.Id;
            return View();
        }

        [HttpGet]
        public ActionResult UserProfile(ProfileModel model,string ID)
        {


            var booking = new ProfileModel();

            booking.datein = model.datein;
            booking.dateout = model.Date;
            booking.SerialNo = model.SerialNo;
            booking.Email = model.Email;
            booking.DeviceName = model.DeviceName;
            booking.status = model.status;
            booking.type = model.type;
            booking.JobCard = model.JobCard;
            booking.Name = model.Name;
            booking.Surname = model.Surname;
            booking.IdentityNumber = model.IdentityNumber;
            booking.JobCard = model.JobCard;
            booking.CellNo = model.CellNo;
            booking.Address = model.Address;
            booking.Country = model.Country;
            booking.Address = model.Address;
            booking.AreaCode = model.AreaCode;
            booking.Date = model.Date;
            booking.Email = model.Email;
            booking.Province = model.Province;
            booking.Title = model.Title;
            booking.DateOfBirth = model.DateOfBirth;
      

            return View();
        }



        [HttpPost]
        public ActionResult UserProfile([Bind(Include = "Id,BookingID,Name,Surname,IdentityNumber,Address,CellNo,Date,Clerk,Technician,JobCard,Title,Country,Province,AreaCode,DateOfBirth,Model,SerialNo,Signature,Email,DeviceName,type,datein,dateout,status")] ProfileModel model)
        {
            TempData.Keep();

            if (ModelState.IsValid)
            {
                var booking = new ProfileModel();


                booking.datein = model.datein;
                booking.dateout = model.Date;
                booking.SerialNo = model.SerialNo;
                booking.Email = model.Email;
                booking.DeviceName = model.DeviceName;
                booking.status = model.status;
                booking.type = model.type;
                booking.JobCard = model.JobCard;
                booking.Name = model.Name;
                booking.Surname = model.Surname;
                booking.IdentityNumber = model.IdentityNumber;
                booking.JobCard = model.JobCard;
                booking.CellNo = model.CellNo;
                booking.Address = model.Address;
                booking.Country = model.Country;
                booking.Address = model.Address;
                booking.AreaCode = model.AreaCode;
                booking.Date = model.Date;
                booking.Email = model.Email;
                booking.Province = model.Province;
                booking.Title = model.Title;
                booking.DateOfBirth = model.DateOfBirth;
                booking.Id = User.Identity.GetUserId();












                Session["Name"] = model.Name;
                TempData["Surname"] = model.Surname;

                TempData["JobCard"] = model.JobCard;
                Session["IdentityNumber"] = model.IdentityNumber;
                TempData["CellNo"] = model.CellNo;
                TempData["Address"] = model.Address;
             
                TempData["Country"] = model.Country;

                TempData["AreaCode"] = model.AreaCode;
                TempData["Province"] = model.Province;
                TempData["Email"] = model.Email;
                TempData["Date"] = model.Surname;
                TempData["DateOfBirth"] = model.Name;
                TempData["Surname"] = model.Surname;
                TempData["UserID"] = model.Id;




                db.Profiles.Add(booking);
                db.SaveChanges();

                return View();

            }
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,serialNo,technician,customerIdNumber,DeviceName,type,model,datein,dateout,status")] DeviceModel deviceModel)
        {
            if (ModelState.IsValid)
            {
                db.DeviceModels.Add(deviceModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(deviceModel);
        }
     
    }

    

//@{
//var name = @TempData["Name"];
//}

//@Html.TextBoxFor(a=>a.Name,htmlAttributes:new {Value=name})


    //// GET: Booking


    //// GET: Booking/Details/5
    //public ActionResult Details(int? id)
    //{
    //    if (id == null)
    //    {
    //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
    //    }
    //    BookingViewModel bookingViewModel = db.BookingViewModels.Find(id);
    //    if (bookingViewModel == null)
    //    {
    //        return HttpNotFound();
    //    }
    //    return View(bookingViewModel);
    //}

    //// GET: Booking/Create
    //public ActionResult Create()
    //{
    //    ViewBag.Id = new SelectList(db.ApplicationUsers, "Id", "Email");
    //    return View();
    //}

    //// POST: Booking/Create
    //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    //[HttpPost]
    //[ValidateAntiForgeryToken]
    //public ActionResult Create([Bind(Include = "BookingID,Name,Surname,IdentityNumber,Address,CellNo,Device,Date,Clerk,Technician,JobCard,Title,Country,Province,AreaCode,DateOfBirth,Model,SerialNo,Signature,Email,Id")] BookingViewModel bookingViewModel)
    //{
    //    if (ModelState.IsValid)
    //    {
    //        db.BookingViewModels.Add(bookingViewModel);
    //        db.SaveChanges();
    //        return RedirectToAction("Index");
    //    }

    //    ViewBag.Id = new SelectList(db.ApplicationUsers, "Id", "Email", bookingViewModel.Id);
    //    return View(bookingViewModel);
    //}

    //// GET: Booking/Edit/5
    //public ActionResult Edit(int? id)
    //{
    //    if (id == null)
    //    {
    //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
    //    }
    //    BookingViewModel bookingViewModel = db.BookingViewModels.Find(id);
    //    if (bookingViewModel == null)
    //    {
    //        return HttpNotFound();
    //    }
    //    ViewBag.Id = new SelectList(db.ApplicationUsers, "Id", "Email", bookingViewModel.Id);
    //    return View(bookingViewModel);
    //}

    //// POST: Booking/Edit/5
    //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    //[HttpPost]
    //[ValidateAntiForgeryToken]
    //public ActionResult Edit([Bind(Include = "BookingID,Name,Surname,IdentityNumber,Address,CellNo,Device,Date,Clerk,Technician,JobCard,Title,Country,Province,AreaCode,DateOfBirth,Model,SerialNo,Signature,Email,Id")] BookingViewModel bookingViewModel)
    //{
    //    if (ModelState.IsValid)
    //    {
    //        db.Entry(bookingViewModel).State = EntityState.Modified;
    //        db.SaveChanges();
    //        return RedirectToAction("Index");
    //    }
    //    ViewBag.Id = new SelectList(db.ApplicationUsers, "Id", "Email", bookingViewModel.Id);
    //    return View(bookingViewModel);
    //}

    //// GET: Booking/Delete/5
    //public ActionResult Delete(int? id)
    //{
    //    if (id == null)
    //    {
    //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
    //    }
    //    BookingViewModel bookingViewModel = db.BookingViewModels.Find(id);
    //    if (bookingViewModel == null)
    //    {
    //        return HttpNotFound();
    //    }
    //    return View(bookingViewModel);
    //}

    //// POST: Booking/Delete/5
    //[HttpPost, ActionName("Delete")]
    //[ValidateAntiForgeryToken]
    //public ActionResult DeleteConfirmed(int id)
    //{
    //    BookingViewModel bookingViewModel = db.BookingViewModels.Find(id);
    //    db.BookingViewModels.Remove(bookingViewModel);
    //    db.SaveChanges();
    //    return RedirectToAction("Index");
    //}

    //protected override void Dispose(bool disposing)
    //{
    //    if (disposing)
    //    {
    //        db.Dispose();
    //    }
    //    base.Dispose(disposing);
    //}
}