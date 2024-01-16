using System.Data;

namespace DevFreelaCQRS.Core.Entities
{
    public class ProjectComment : BaseEntity
    {
        public ProjectComment(string content, Guid projectId, Guid userId) 
        { 
            Content = content;
            ProjectId = projectId;
            UserId = userId;
            Active = true;
            CreatedAt = DateTime.Now;
        }

        public string Content { get; private set; }
        public Guid ProjectId { get; private set; }
        public Project Project { get; private set; }
        public Guid UserId { get; private set; }
        public User User { get; private set; }
        
        public void Update(string content)
        {
            Content = content;
        }
    }
}
