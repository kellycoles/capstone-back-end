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
                var customerOptions = Customers?.Select(c => new SelectListItem(c.FullName, c.CustomerId.ToString())).ToList();
                customerOptions.Insert(0, new SelectListItem()
                {
                    Value = string.Empty,
                    Text = "Select Customer"
                });
                return (customerOptions);
            }
        }
        public List<Service> Services { get; set; }
        public List<SelectListItem> ServiceOptions
        {
            get
            {
                var serviceOptions = Services?.Select(c => new SelectListItem(c.Name, c.ServiceId.ToString())).ToList();
                serviceOptions.Insert(0, new SelectListItem()
                  {
                    Value = string.Empty,
                    Text = "Select Service"
                  });
                return (serviceOptions);
            }
        }
    }
}
