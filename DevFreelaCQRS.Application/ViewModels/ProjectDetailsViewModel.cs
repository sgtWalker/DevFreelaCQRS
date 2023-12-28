using DevFreelaCQRS.Core.Enums;

namespace DevFreelaCQRS.Application.ViewModels
{
    public class ProjectDetailsViewModel
    {
        public ProjectDetailsViewModel(Guid id, string title, string description, DateTime? startedAt, DateTime? finishedAt, decimal totalCost, ProjectStatus status, string clientFullName, string freelancerFullName)
        {
            Id = id;
            Title = title;
            Description = description;
            StartedAt = startedAt;
            FinishedAt = finishedAt;
            TotalCost = totalCost;
            Status = status;
            ClientFullName = clientFullName;
            FreelancerFullName = freelancerFullName;
        }

        public Guid Id { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public DateTime? StartedAt { get; private set; }
        public DateTime? FinishedAt { get; private set; }
        public decimal TotalCost { get; private set; }
        public ProjectStatus Status { get; private set; }
        public string ClientFullName { get; private set; }
        public string FreelancerFullName { get; private set; }
    }
}
