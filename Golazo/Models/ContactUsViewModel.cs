using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Golazo.Models
{
    [Table("tblContactUs")]
    public class ContactUs
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Full Name")]
        public string Name { get; set; }

        [Display(Name = "Phone No")]
        [Required]
        public string PhoneNo { get; set; }

        [Required]
        [Display(Name = "Message")]
        [DataType(DataType.MultilineText)]
        public string Message { get; set; }
    }
}