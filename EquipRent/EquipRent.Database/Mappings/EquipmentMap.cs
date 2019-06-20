using FluentNHibernate.Mapping;
using EquipRent.Database.Entities;

namespace Restaurant.Database.Mappings
{
    public class EquipmentMap : ClassMap<Equipment>
    {
        public EquipmentMap()
        {
            Table("Equipment");
            Id(x => x.Id);
            Map(x => x.State, "State").Not.Nullable();
            References(x => x.Model, "ModelId").Not.LazyLoad();
        }
    }
}
