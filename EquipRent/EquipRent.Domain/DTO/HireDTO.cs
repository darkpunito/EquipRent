using EquipRent.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipRent.Domain.DTO
{
    public class HireDTO
    { 
        public int Id { get; set; }
        public string Status { get; set; }
        public ApplicationUser User { get; set; }

        public EquipmentDTO Equipment { get; set; }
    }
}
