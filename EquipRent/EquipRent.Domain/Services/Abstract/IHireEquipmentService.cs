using EquipRent.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipRent.Domain.Services.Abstract
{
    public interface IHireEquipmentService
    {
        IList<ModelDTO> GetModels();        
    }
}
