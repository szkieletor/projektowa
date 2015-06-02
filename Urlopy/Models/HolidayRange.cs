using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Urlopy.Models
{
    public class HolidayRange
    {
        public int ID { get; set; }
        public int HolidayID { get; set; }

        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public string Kind { get; set; }

        public virtual ICollection<HolidayRangeHistory> HolidayRangeHistories { get; set; }

        public virtual Holiday Holiday { get; set; }

        public HolidayRange(HolidayRangeViewModel vm)
        {
            DateFrom = vm.StartDate;
            DateTo = vm.EndDate;
        }
    }
}