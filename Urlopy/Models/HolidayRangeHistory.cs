using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Urlopy.Models
{
    public class HolidayRangeHistory
    {
        public int ID { get; set; }
        public int HolidayRangeID { get; set; }
        public string OperationType { get; set; }

        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public string Kind { get; set; }

        public virtual HolidayRange HolidayRange { get; set; }

    }
}