namespace EquipRent.Database.Entities
{
    public class Hire
    {
        public virtual int Id { get; set; }
        public virtual Equipment Equipment { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual string Status { get; set; }
    }
}
