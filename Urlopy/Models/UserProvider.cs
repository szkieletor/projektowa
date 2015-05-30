using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;

namespace Urlopy.Models
{
    public class UserProvider
    {
        public UserManager<ApplicationUser> UserManager { get; set; }
        public UserProvider()
            : this(new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext())))
        {

        }

        public UserProvider(UserManager<ApplicationUser> userManager)
        {
            // TODO: Complete member initialization
            UserManager = userManager;
        }
    }
}