using EquipRent.Database.Entities;
using System.Collections.Generic;


namespace EquipRent.Database.Repositories.Abstract
{
    public interface IHireRepository
    {
        IList<Hire> GetHires();
        void HireEquipment(int equipmentId, ApplicationUser currentUser);
        void CancelReservation(int reservationId);
        void EditReservation(int id, string selectedStatus);
    }
}
