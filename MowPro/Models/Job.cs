using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MowPro.Models
{
    public class Job
    {
        [Key]
        public int JobId { get; set; }
        [Required]
        public DateTime Date { get; set; }
        public bool Paid { get; set; }
        public int CustomerServiceId { get; set; }
    }
}
