using EquipRent.Database.Entities;
using EquipRent.Database.Repositories.Abstract;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipRent.Database.Repositories.Concrete
{
    public class HireRepository : IHireRepository
    {
        private NHibernate.ISessionFactory _sessionFactory { get; }

        public HireRepository(IEquipRentSessionFactory sessionFactory)
        {
            _sessionFactory = sessionFactory.CreateSessionFactory();
        }

        public IList<Equipment> GetEquipments(int modelId)
        {
            using (ISession session = _sessionFactory.OpenSession())
            {
                return session.Query<Equipment>().Where(x => x.Model.Id == modelId).ToList();
            }
        }
        public IList<Hire> GetHires()
        {
            using (ISession session = _sessionFactory.OpenSession())
            {
                return session.Query<Hire>().ToList();
            }
        }

        public void HireEquipment(int equipmentId, ApplicationUser currentUser)
        {
            using (ISession session = _sessionFactory.OpenSession())
            {
                var equipment = session.Query<Equipment>().First(e => e.Id == equipmentId);
                var hire = new Hire()
                {
                    Equipment = equipment,
                    User = currentUser,
                    Status = "Zarezerwowany"
                };
                session.Save(hire);
            }
        }

        public void CancelReservation(int reservationId)
        {
            using (ISession session = _sessionFactory.OpenSession())
            {

                var hireToCancel = session.Query<Hire>().First(x => x.Id == reservationId);
                if (hireToCancel != null)
                {                    
                        session.Delete(hireToCancel);
                        session.Flush(); 
                }
                else
                {
                    throw new KeyNotFoundException("Key not found in database");
                }               
            }
        }

        public void EditReservation(int reservationId, string selectedStatus)
        {
            using (ISession session = _sessionFactory.OpenSession())
            {

                var hireToEdit = session.Query<Hire>().First(x => x.Id == reservationId);
                hireToEdit.Status = selectedStatus;
                session.Update(hireToEdit);
                session.Flush();
            }
        }
    }   
}
