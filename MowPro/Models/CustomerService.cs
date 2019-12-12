using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MowPro.Models
{
    public class CustomerService
    {
        [Key]
        public int CustomerServiceId { get; set; }
        public string Notes { get; set; }
        [Required]
        public int Cost { get; set; }
        [Required]
        public int CustomerId { get; set; }
        [Required]
        public int ServiceId { get; set; }

    }
}
