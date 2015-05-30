using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Urlopy.Models;

namespace Urlopy.Controllers
{
    public class AdministrationController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        //
        // GET: /Administration/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult EmployeeList()
        {
            var employeeList = db.Users.ToList<ApplicationUser>();
            return View(employeeList);
        }
        public ActionResult ManageUserRoles()
        {
            var temp = db.Users.ToList<ApplicationUser>();
            var temp2 = db.Roles.ToList<Microsoft.AspNet.Identity.EntityFramework.IdentityRole>();
            ViewBag.UsersList = temp;
            ViewBag.RolesList = temp2;
            return View();
        }
        [HttpPost]
        public ActionResult ManageUserRoles(FormCollection form)
        {
            if(form["id"] == "1")
            { 
                string userId = form["user"];
                string userRole = form["role"];
                var account = new AccountController();
                IdentityResult x = account.UserManager.AddToRole(userId, userRole);
            }
            if(form["id"] == "2")
            {
                string userId = form["user2"];
                string userRole = form["role2"];
                var account = new AccountController();
                if (account.UserManager.IsInRole(userId, userRole))
                { 
                IdentityResult x = account.UserManager.RemoveFromRole(userId, userRole);
                }
            }
            if(form["id"] == "3")
            {
                string userId = form["user3"];
                var account = new AccountController();
                ViewBag.RolesForThisUser = account.UserManager.GetRoles(userId);
            }
            var temp = db.Users.ToList<ApplicationUser>();
            var temp2 = db.Roles.ToList<Microsoft.AspNet.Identity.EntityFramework.IdentityRole>();
            ViewBag.UsersList = temp;
            ViewBag.RolesList = temp2;

            return View();
        }
	}
}