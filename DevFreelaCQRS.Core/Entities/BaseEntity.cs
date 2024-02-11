using Microsoft.VisualBasic.FileIO;

namespace DevFreelaCQRS.Core.Entities
{
    public abstract class BaseEntity
    {
        protected BaseEntity() { }

        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; private set; }
        public DateTime? DeletedAt { get; private set; }
        public bool Active { get; set; }

        public void Delete()
        {
            this.Active = false;
            this.DeletedAt = DateTime.Now;
        }
    }
}
