namespace Domain.Entities
{
    public abstract class EntityBase
    {
        public int Id { get; set; }
        public bool Deleted { get; set; }
        public DateTime? DeletedDate { get; set; }
    }
}
