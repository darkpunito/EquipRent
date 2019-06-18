using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.AspNet.Identity.Helpers;
using NHibernate.Tool.hbm2ddl;
using System.Reflection;

namespace EquipRent.Database
{
    public interface IEquipRentSessionFactory
    {
        ISessionFactory CreateSessionFactory();
        ISession Session { get; set; }
    }
    public class EquipRentSessionFactory : IEquipRentSessionFactory
    {
        public ISessionFactory CreateSessionFactory()
        {
            return Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2008
                  .ConnectionString(@"Server=tcp:pwywrot.database.windows.net,1433;Initial Catalog=Equip;Persist Security Info=False;User ID=pwywrot;Password=chomik123#;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;")
                              .ShowSql()
                )
               .ExposeConfiguration(cfg => cfg.AddDeserializedMapping(MappingHelper.GetIdentityMappings(new[] { typeof(ApplicationUser) }), null))
               .Mappings(m =>
                          m.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly()))
                .BuildSessionFactory();
        }
        public ISession Session
        {
            get {
                return CreateSessionFactory().OpenSession();
            }
            set
            {
                Session = value;
            }
        }
    }
}
