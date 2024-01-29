namespace DevFreelaCQRS.Core.Entities
{
    public class User : BaseEntity
    {
        public User(string fullName, string email, DateTime birthDate, string password, string role)
        {
            FullName = fullName;
            Email = email;
            BirthDate = birthDate;
            Skills = new List<UserSkill>();
            OwnedProjects = new List<Project>();
            FreelanceProjects = new List<Project>();
            Active = true;
            CreatedAt = DateTime.Now;
            Password = password;
            Role = role;
        }

        public string FullName { get; private set; }
        public string Email { get; private set; }
        public DateTime BirthDate { get; private set; }
        public List<UserSkill> Skills { get; private set; }
        public List<Project> OwnedProjects { get; private set; }
        public List<Project> FreelanceProjects { get; private set; }
        public List<ProjectComment> Comments { get; private set; }
        public string Password { get; private set; }
        public string Role { get; private set; }

        public void Update(string fullName, string email, DateTime birthDate)
        { 
            FullName = fullName; 
            Email = email; 
            BirthDate = birthDate;
        }
    }
}
