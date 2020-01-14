using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MowPro.Models.ViewModels
{
    public class CustomerEditViewModel: CustomerCreateViewModel
    {
        public int id { get; set; }
        public string ExistingPhotoPath { get; set; }
    }
}
