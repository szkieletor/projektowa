using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.Data.Entity;

namespace Urlopy.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
         public int LoginFromLdap { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int percentagesOfTime { get; set; }
        public int daysForYear { get; set; }
        public int daysLeft { get; set; }
        public virtual ApplicationUser Supervisor { get; set; }
        public virtual ICollection<Holiday> Holidays { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Holiday> Holidays { get; set; }
        public ApplicationDbContext()
            : base("DefaultConnection")
        { }
    }

}