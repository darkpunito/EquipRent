using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EquipRent.WebApplication.Models
{
    public class HireViewModel
    {
        [Display(Name = "Zmien status zamowienia")]
        public string SelectedStatus { get; set; }
        public List<SelectListItem> StateSelections { get; set; }
        public EquipmentViewModel Hire {get;set;}
    }
}