using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MowPro.Models
{
    public class Service
    {
        [Key]
        public int ServiceId { get; set; }
        [Required]
        [Display(Name = "Service")]
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        public string Description { get; set; }
        [Required]
        public string UserId { get; set; }
   
        public ApplicationUser User { get; set; }
      
    }
}
