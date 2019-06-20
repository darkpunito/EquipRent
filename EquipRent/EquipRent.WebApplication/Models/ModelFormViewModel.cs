using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EquipRent.WebApplication.Models
{
    public class ModelFormViewModel
    {
        public List<ModelViewModel> Models { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}