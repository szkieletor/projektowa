using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Urlopy.Models
{
    public class Holiday
    {
        public int ID { get; set; }
        public string ApplicationUserId { get; set; }

        [DefaultValue (0)]
        public HolidayStatus Status { get; set; }

        [DisplayName("Data rozpoczęcia")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyy}")]
        [DataType(DataType.Date)]
        public DateTime DateFrom { get; set; }
        [DisplayName("Data zakończenia")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyy}")]
        public DateTime DateTo { get; set; }
        [DisplayName("Komentarz")]
        public string Comment { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        public int GetTotalBusinessDays()
        {
            var dayCount = 0;

            for (var currentDate = DateFrom; currentDate.Date <= DateTo;currentDate = currentDate.AddDays(1))
            {
                if (currentDate.DayOfWeek != DayOfWeek.Sunday && currentDate.DayOfWeek != DayOfWeek.Saturday)
                {
                    dayCount++;
                }
            }
            return dayCount;
        }
    }
}