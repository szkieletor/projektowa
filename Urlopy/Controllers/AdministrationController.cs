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
	}
}