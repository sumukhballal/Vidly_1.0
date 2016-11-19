using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace Vidly.Models
{
    public class Customer
    {
        [Required]
        [StringLength(255)]
        [Display(Name = "Customer Name")]
        public string CustomerName { get; set; }

        public int CustomerId { get; set; }

        public bool iscustomersuscribedtonewsletter { get; set; }

        
        public MembershipType MembershipType { get; set; }

        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }

        [Display(Name ="Date Of Birth")]
        [min18yearsofage]
        public DateTime? birthdate { get; set; }

    }
}