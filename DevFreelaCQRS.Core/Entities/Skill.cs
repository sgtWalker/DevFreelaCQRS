namespace DevFreelaCQRS.Core.Entities
{
    public class Skill : BaseEntity
    {
        public Skill(string description)
        {
            Description = description;
            Active = true;
            CreatedAt = DateTime.Now;
        }

        public string Description { get; private set; }
    }
}
