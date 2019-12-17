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
      
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public string Notes { get; set; }
   

        public bool Paid { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}")]
        public double Cost { get; set; }

        [Display(Name = "Complete")]
        public bool IsComplete { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public int ServiceId { get; set; }
        public Service Service { get; set; }
    }
}
