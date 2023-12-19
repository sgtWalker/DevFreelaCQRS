namespace DevFreelaCQRS.Core.Entities
{
    public class User : BaseEntity
    {
        public User(string fullName, string email, DateTime birthDate, List<UserSkill> skills, List<Project> ownedProjects, List<Project> freelanceProjects)
        {
            FullName = fullName;
            Email = email;
            BirthDate = birthDate;
            Skills = skills;
            OwnedProjects = ownedProjects;
            FreelanceProjects = freelanceProjects;
            Active = true;
            CreatedAt = DateTime.Now;
        }

        public string FullName { get; private set; }
        public string Email { get; private set; }
        public DateTime BirthDate { get; private set; }
        public List<UserSkill> Skills { get; private set; }
        public List<Project> OwnedProjects { get; private set; }
        public List<Project> FreelanceProjects { get; private set; }
        public List<ProjectComment> Comments { get; private set; }

    }
}
