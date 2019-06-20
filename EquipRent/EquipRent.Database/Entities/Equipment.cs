namespace EquipRent.Database.Entities
{
    public class Equipment
    {
        public virtual int Id { get; set; }
        public virtual Model Model { get; set; }
        public virtual string State { get; set; }
    }
}
