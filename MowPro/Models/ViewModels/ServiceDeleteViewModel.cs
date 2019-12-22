using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MowPro.Models.ViewModels
{
    public class ServiceDeleteViewModel
    {
        public Job Job { get; set; }
        public Service Service{ get; set; }
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }
    }
}
