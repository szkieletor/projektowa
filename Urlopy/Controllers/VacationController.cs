using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Urlopy.Models;

namespace Urlopy.Controllers
{
    [Authorize]
    public class VacationController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /Vacation/
        public ActionResult Index()
        {
            var holidays = db.Holidays.Include(h => h.ApplicationUser);
            return View(holidays.ToList());
        }

        // GET: /Vacation/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Holiday holiday = db.Holidays.Find(id);
            if (holiday == null)
            {
                return HttpNotFound();
            }
            return View(holiday);
        }

        // GET: /Vacation/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Vacation/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,ApplicationUserId,Status,DateFrom,DateTo")] Holiday holiday)
        {
            if (ModelState.IsValid)
            {
                UserProvider provider = new UserProvider();
                var currentUser = provider.UserManager.FindById(User.Identity.GetUserId());
                holiday.ApplicationUser = currentUser;
                db.Holidays.Add(holiday);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            //ViewBag.ApplicationUserId = new SelectList(db.IdentityUsers, "Id", "UserName", holiday.ApplicationUserId);
            return View(holiday);
        }

        // GET: /Vacation/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Holiday holiday = db.Holidays.Find(id);
            if (holiday == null)
            {
                return HttpNotFound();
            }
            //ViewBag.ApplicationUserId = new SelectList(db.IdentityUsers, "Id", "UserName", holiday.ApplicationUserId);
            return View(holiday);
        }

        // POST: /Vacation/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,ApplicationUserId,Status,DateFrom,DateTo")] Holiday holiday)
        {
            if (ModelState.IsValid)
            {
                db.Entry(holiday).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //ViewBag.ApplicationUserId = new SelectList(db.IdentityUsers, "Id", "UserName", holiday.ApplicationUserId);
            return View(holiday);
        }

        // GET: /Vacation/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Holiday holiday = db.Holidays.Find(id);
            if (holiday == null)
            {
                return HttpNotFound();
            }
            return View(holiday);
        }

        // POST: /Vacation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Holiday holiday = db.Holidays.Find(id);
            db.Holidays.Remove(holiday);
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
