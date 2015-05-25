using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Urlopy.Models
{
    public class Holiday
    {
        public int ID { get; set; }
        public int UserID { get; set; }

        public string Status { get; set; }

        public string User { get; set; }
        public virtual ICollection<HolidayRange> HolidayRanges { get; set; }

        
    }
}