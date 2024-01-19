namespace DevFreelaCQRS.Application.ViewModels
{
    public class UserSkillsViewModel
    {
        public UserSkillsViewModel(string fullName, string email, List<SkillViewModel>? skills)
        {
            FullName = fullName;
            Email = email;
            Skills = skills;
        }

        public string FullName { get; private set; }
        public string Email { get; private set; }
        public List<SkillViewModel>? Skills { get; private set; }
    }
}
