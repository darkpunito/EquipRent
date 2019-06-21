using AutoMapper;
using EquipRent.Database;
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
        private IHireRepository hireRepository;
        private IEquipmentRepository equipmentRepository;

        public HireEquipmentService(IModelRepository modelRepository, IEquipmentRepository equipmentRepository, IHireRepository hireRepository)
        {
            this.modelRepository = modelRepository;
            this.equipmentRepository = equipmentRepository;
            this.hireRepository = hireRepository;
        }

        public void CancelReservation(int reservationId)
        {
            hireRepository.CancelReservation(reservationId);
        }

        public void EditReservation(int reservationId, string selectedStatus)
        {
            hireRepository.EditReservation(reservationId, selectedStatus);
        }

        public IList<EquipmentDTO> GetEquipments(int modelId)
        {
            var equipmentsForModel = equipmentRepository.GetEquipments(modelId);
            for (int i= equipmentsForModel.Count -1 ; i >= 0; i--)
            {
                /*var equipmentHires =*/ if (hireRepository.GetHires().Any(x => x.Equipment.Id == equipmentsForModel[i].Id))
                {
                    equipmentsForModel.RemoveAt(i);
                }
            }
            return Mapper.Map<List<EquipmentDTO>>(equipmentsForModel);
        }

        public IList<HireDTO> GetHires()
        {
            return Mapper.Map<List<HireDTO>>(hireRepository.GetHires());
        }

        public IList<ModelDTO> GetModels()
        {
            var allModels = modelRepository.GetModels();
            return Mapper.Map<List<ModelDTO>>(allModels);

        }

        public void hireEquipment(int equipmentId, ApplicationUser userId)
        {
            hireRepository.HireEquipment(equipmentId, userId);
        }
    }
}
