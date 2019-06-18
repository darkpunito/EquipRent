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
    public class ModelRepository : IModelRepository
    {
        private NHibernate.ISessionFactory _sessionFactory { get; }

        public ModelRepository(IEquipRentSessionFactory sessionFactory)
        {
            _sessionFactory = sessionFactory.CreateSessionFactory();
        }
        public IList<Model> GetModels()
        {
            using (ISession session = _sessionFactory.OpenSession())
            {
                return session.Query<Model>().ToList();
            }
        }
    }
}
