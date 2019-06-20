
using EquipRent.Database;
using EquipRent.Domain.DTO;

namespace EquipRent.WebApplication.Models
{
    public class EquipmentViewModel
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public ApplicationUser User { get; set; }
        public EquipmentDTO Equipment { get; set; }


    }
}