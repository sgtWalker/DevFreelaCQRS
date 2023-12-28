namespace DevFreelaCQRS.Application.ViewModels
{
    public class ProjectViewModel
    {
        public ProjectViewModel(Guid id, string title, DateTime createdAt)
        {
            Id = id;
            Title = title;
            CreatedAt = createdAt;
        }

        public Guid Id { get; private set; }
        public string Title { get; private set; }
        public DateTime CreatedAt { get; private set; }
    }
}
