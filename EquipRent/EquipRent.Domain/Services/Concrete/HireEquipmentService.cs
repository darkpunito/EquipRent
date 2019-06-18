using AutoMapper;
using EquipRent.Database.Repositories.Abstract;
using EquipRent.Domain.DTO;
using EquipRent.Domain.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipRent.Domain.Services.Concrete
{
    public class HireEquipmentService : IHireEquipmentService
    {
        private IModelRepository modelRepository;

        public HireEquipmentService(IModelRepository modelRepository)
        {
            this.modelRepository = modelRepository;
        }

        public IList<ModelDTO> GetModels()
        {
            var allModels = modelRepository.GetModels().ToList();
            return Mapper.Map<List<ModelDTO>>(allModels);

        }
    }
}
