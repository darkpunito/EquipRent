using System.Collections.Generic;

namespace EquipRent.WebApplication.Models
{
    public class ReservationViewModel
    {
        public int Id { get; set; }
        public List<EquipmentViewModel> Equipment { get; set; }
    }
}