using EquipRent.Database;
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
        IList<EquipmentDTO> GetEquipments(int modelId);
        void hireEquipment(int equipmentId, ApplicationUser userId);
        IList<HireDTO> GetHires();
        void CancelReservation(int reservationId);
        void EditReservation(int reservationId, string selectedStatus);
    }
}
