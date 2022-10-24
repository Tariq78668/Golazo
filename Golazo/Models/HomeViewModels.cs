using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace Golazo.Models
{
    [Table("tblTeam")]
    public class Team
    {
        [Required]
        [Display(Name = "TeamID")]
        public int ID { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }

        public virtual ICollection<ApplicationUser> TeamMember { get; set; }
    }

   
}