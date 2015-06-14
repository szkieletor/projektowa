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
        private UserProvider()
        {

        }

        public UserProvider(ApplicationDbContext context) :
            this(new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context)))
        {

        }

        public UserProvider(UserManager<ApplicationUser> userManager)
        {
            // TODO: Complete member initialization
            UserManager = userManager;
        }
    }
}