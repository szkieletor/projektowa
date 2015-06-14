namespace Urlopy.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Urlopy.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<Urlopy.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Urlopy.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var RoleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            var roleList = new List<string>();
            roleList.Add("Admin");
            roleList.Add("Employee");

            foreach (var role in roleList)
            {
                if (!RoleManager.RoleExists(role))
                {
                    var result = RoleManager.Create(new IdentityRole(role));
                }
            }

            if (UserManager.FindByName("admin") == null)
            {
                IPasswordHasher hasher = new PasswordHasher();
                var roles = context.Roles.ToList();
                ApplicationUser user = new ApplicationUser
                {
                    Name = "admin",
                    PasswordHash = hasher.HashPassword("admin"),
                    UserName = "admin",
                    Surname = "adminSurname",
                };
                UserManager.Create(user);

                foreach (var role in roleList)
                {
                    if (!UserManager.IsInRole(user.Id, role));
                    {
                        UserManager.AddToRole(user.Id, role);
                    }
                }
            }
        }
    }
}
