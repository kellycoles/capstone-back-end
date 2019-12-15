using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MowPro.Models.ViewModels
{
    public class JobCreateViewModel
    {
        public Job Job { get; set; }

        public List<Customer> Customers { get; set; }
        public List<SelectListItem> CustomerOptions
        {
            get
            {
                return Customers?.Select(c => new SelectListItem(c.FullName, c.CustomerId.ToString())).ToList();
            }
        }
        public List<Service> Services { get; set; }
        public List<SelectListItem> ServiceOptions
        {
            get
            {
                return Services?.Select(c => new SelectListItem(c.Name, c.ServiceId.ToString())).ToList();
            }
        }
    }
}
