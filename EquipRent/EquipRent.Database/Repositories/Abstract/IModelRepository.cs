using EquipRent.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipRent.Database.Repositories.Abstract
{
    public interface IModelRepository
    {
        IList<Model> GetModels();
    }
}
