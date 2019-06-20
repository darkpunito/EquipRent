using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipRent.Domain.DTO
{
    public class EquipmentDTO
    {
        public int Id { get; set; }
        public string State { get; set; }
        public ModelDTO Model { get; set; }
    }
}
