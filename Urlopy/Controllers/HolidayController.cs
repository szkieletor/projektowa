using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Urlopy.Models;

namespace Urlopy.Controllers
{
    public class HolidayController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        private UserManager<ApplicationUser> UserManager;
        // GET: /Holiday/
        public ActionResult Index()
        {
            var holidayranges = db.HolidayRanges.Include(h => h.Holiday);
            return View(holidayranges.ToList());
        }

        // GET: /Holiday/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HolidayRange holidayrange = db.HolidayRanges.Find(id);
            if (holidayrange == null)
            {
                return HttpNotFound();
            }
            return View(holidayrange);
        }

        // GET: /Holiday/Create
        public ActionResult Create()
        {
            ViewBag.HolidayID = new SelectList(db.Holidays, "ID", "Status");
            return View();
        }

        // POST: /Holiday/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,HolidayID,DateFrom,DateTo,Kind")] HolidayRange holidayrange)
        {
            if (ModelState.IsValid)
            {
                db.HolidayRanges.Add(holidayrange);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.HolidayID = new SelectList(db.Holidays, "ID", "Status", holidayrange.HolidayID);
            return View(holidayrange);
        }

        // GET: /Holiday/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HolidayRange holidayrange = db.HolidayRanges.Find(id);
            if (holidayrange == null)
            {
                return HttpNotFound();
            }
            ViewBag.HolidayID = new SelectList(db.Holidays, "ID", "Status", holidayrange.HolidayID);
            return View(holidayrange);
        }
        public ActionResult ToPDF(int? id)
        {
            UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            HolidayRange holidayrange = db.HolidayRanges.Find(id);
            //if (holidayrange == null)
            //{
            //    return HttpNotFound();
            //}
            ApplicationUser user = UserManager.FindById(User.Identity.GetUserId());
            ViewBag.User = user;
            //ViewBag.UserName = user.Name + " " + user.Surname;
            return new RazorPDF.PdfResult(holidayrange,"Pdf");
        }
        // POST: /Holiday/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,HolidayID,DateFrom,DateTo,Kind")] HolidayRange holidayrange)
        {
            if (ModelState.IsValid)
            {
                db.Entry(holidayrange).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.HolidayID = new SelectList(db.Holidays, "ID", "Status", holidayrange.HolidayID);
            return View(holidayrange);
        }

        // GET: /Holiday/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HolidayRange holidayrange = db.HolidayRanges.Find(id);
            if (holidayrange == null)
            {
                return HttpNotFound();
            }
            return View(holidayrange);
        }

        // POST: /Holiday/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HolidayRange holidayrange = db.HolidayRanges.Find(id);
            db.HolidayRanges.Remove(holidayrange);
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
