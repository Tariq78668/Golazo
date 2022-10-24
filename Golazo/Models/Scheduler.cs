using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
namespace Golazo.Models
{

    [Table("tblScheduler")]
    public class Scheduler
    {
        [Required]
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Team Name")]
        public string TeamName { get; set; }

      
        [Display(Name = "Team ")]
        public int TeamId { get; set; }


        [Display(Name = "Ground Name")]
        public string GroundName { get; set; }

        [Display(Name = "Choose Start Time")]
        [DataType(DataType.DateTime)]
        public DateTime StartTime { get; set; }

        [Display(Name = "Choose End Time")]
        [DataType(DataType.DateTime)]
        public DateTime EndTime { get; set; }
        public bool SelfPaid { get; set; }
        public bool PaidByTeam { get; set; }
    }
}