namespace DevFreelaCQRS.Core.Entities
{
    public abstract class BaseEntity
    {
        protected BaseEntity() { }

        public Guid Id { get; private set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; private set; }
        public DateTime? DeletedAt { get; private set; }
        public bool Active { get; set; }
    }
}
