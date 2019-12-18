using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MowPro.Models.ViewModels
{
    public class EditJobViewModel
    {
        public Job Job { get; set; }
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
