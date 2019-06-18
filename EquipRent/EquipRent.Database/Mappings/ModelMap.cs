using FluentNHibernate.Mapping;
using EquipRent.Database.Entities;

namespace Restaurant.Database.Mappings
{
    public class ModelMap : ClassMap<Model>
    {
        public ModelMap()
        {
            Table("Model");
            Id(x => x.Id);
            Map(x => x.Name, "Name").Not.Nullable();
            Map(x => x.Description, "Description");
        }
    }
}
