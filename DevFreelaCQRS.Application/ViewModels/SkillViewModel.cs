namespace DevFreelaCQRS.Application.ViewModels
{
    public class SkillViewModel
    {
        public SkillViewModel(string description)
        {
            Description = description;
        }

        public string Description { get; private set; }
    }
}
