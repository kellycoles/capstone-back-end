using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MowPro.Models.ViewModels
{
    public class CustomerCreateViewModel
    {

        [Required]
        [MaxLength(20)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(20)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [NotMapped]
        [Display(Name = "Name")]
        public string FullName => $"{FirstName} {LastName}";

        [MaxLength(50)]
        [Required]
        [Display(Name = "Street Address")]
        public string StreetAddress { get; set; }

        [MaxLength(20)]
        public string City { get; set; }

        [MaxLength(50)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [RegularExpression("^\\d{3}-\\d{3}-\\d{4}$", ErrorMessage = "Please enter valid phone .")]

        [Display(Name = "Phone")]
        public string PhoneNumber { get; set; }

        public string Preferences { get; set; }

        public IFormFile Photo { get; set; }

        [Required]
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

    }
}

