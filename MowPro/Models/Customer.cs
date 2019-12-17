using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MowPro.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [NotMapped]
        [Display(Name = "Name")]
        public string FullName => $"{FirstName} {LastName}";

        [Required]
        [Display(Name = "Street Address")]
        public string StreetAddress { get; set; }

        public string City { get; set; }
     

        public string Email { get; set; }
       
        [Display(Name = "Phone")]
        public string PhoneNumber { get; set; }

        public string Preferences { get; set; }


        [Required]
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

    }
}
