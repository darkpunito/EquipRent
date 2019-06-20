using FluentNHibernate.Mapping;
using EquipRent.Database.Entities;

namespace Restaurant.Database.Mappings
{
    public class HireMap : ClassMap<Hire>
    {
        public HireMap()
        {
            Table("Hire");
            Id(x => x.Id);
            Map(x => x.Status, "Status").Not.Nullable();
            References(x => x.User, "UserId").Not.LazyLoad();
            References(x => x.Equipment, "EquipmentId").Not.LazyLoad();
        }
    }
}
