using System.Collections.Generic;
using System.Web.Mvc;

namespace EquipRent.WebApplication.Models
{
    public class HireEquipmentViewModel
    {
        public int SelectEquipment { get; set; }
        public IEnumerable<SelectListItem> EquipmentOptions{ get; set; }

        public ModelViewModel Model { get; set; }
        public List<EquipmentViewModel> Equipments { get; set; }
    }
}
