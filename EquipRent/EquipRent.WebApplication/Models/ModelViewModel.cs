using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EquipRent.WebApplication.Models
{
    public class ModelViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Model Name")]
        public string Name { get; set; }

        [Display(Name = "Model Description")]
        public string Description { get; set; }
        public int NumberOfEquipments { get; set; }
    }
}