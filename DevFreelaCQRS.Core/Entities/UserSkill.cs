namespace DevFreelaCQRS.Core.Entities
{
    public class UserSkill : BaseEntity
    {
        public UserSkill(Guid userId, Guid skillId) 
        { 
            UserId = userId;
            SkillId = skillId;
            Active = true;
            CreatedAt = DateTime.Now;
        }

        public Guid UserId { get; private set; }
        public Guid SkillId { get; private set; }
    }
}
