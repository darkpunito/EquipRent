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
    public class EquipmentRepository: IEquipmentRepository
    {
        private NHibernate.ISessionFactory _sessionFactory { get; }

        public EquipmentRepository(IEquipRentSessionFactory sessionFactory)
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
    }
}
