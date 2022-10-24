using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Golazo.Models
{
    [Table("tblTeamMember")]
    public class TeamMember
    {
        [Required]
        [Display(Name = "Id")]
        public int ID { get; set; }

        [Display(Name = " Team Id")]
        public int TeamId { get; set; }

        [Display(Name = " Team Name")]
        public string TeamName { get; set; }

        [Display(Name = "Select Member")]
        public string MemberId { get; set; }

        [Display(Name = "Member Email")]
        public string MemberEmail { get; set; }
    }
}