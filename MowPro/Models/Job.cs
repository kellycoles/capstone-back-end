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
        [Display(Name = "Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public DateTime Date { get; set; }

        public string Notes { get; set; }
        [Display(Name = "Payment Collected")]

        public bool Paid { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}")]
        public double Cost { get; set; }

        [Display(Name = "Job Complete")]
        public bool IsComplete { get; set; }
        public int CustomerId { get; set; }
        public int ServiceId { get; set; }
    }
}
