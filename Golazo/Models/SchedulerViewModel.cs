using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Golazo.Models
{
    public class SchedulerViewModel
    {
        [Display(Name = "Stadium Name")]
        public string GroundName { get; set; }

        [Display(Name = "Team Name")]
        public string TeamName { get; set; }

        [Required]
        [Display(Name = "Team")]
        public int TeamId { get; set; }

        public int MembersCount { get; set; }

        [Display(Name = "Booking Date")]
        [DataType(DataType.Date)]
        public DateTime BookingDate { get; set; }

        [Display(Name = "Start Time")]
        [DataType(DataType.Time)]
        public DateTime StartTime { get; set; }

        [Display(Name = "End Time")]
        [DataType(DataType.Time)]
        public DateTime EndTime { get; set; }

        [Display(Name = "Payment by")]
        [Required]
        public string PaidBy { get; set; }
       
    }
}