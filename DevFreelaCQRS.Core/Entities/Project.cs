using DevFreelaCQRS.Core.Enums;

namespace DevFreelaCQRS.Core.Entities
{
    public class Project :  BaseEntity
    {
        public Project(string title, string description, Guid clientId, Guid freelancerId, decimal totalCost)
        {
            Title = title;
            Description = description;
            ClientId = clientId;
            FreelancerId = freelancerId;
            TotalCost = totalCost;
            Status = ProjectStatus.Created;
            Comments = new List<ProjectComment>();
            Active = true;
            CreatedAt = DateTime.Now;
        }

        public Project(Guid id, string title, string description, Guid clientId, Guid freelancerId, decimal totalCost)
        {
            Id = id;
            Title = title;
            Description = description;
            ClientId = clientId;
            FreelancerId = freelancerId;
            TotalCost = totalCost;
            Status = ProjectStatus.Created;
            Comments = new List<ProjectComment>();
            Active = true;
            CreatedAt = DateTime.Now;
        }

        public Project(Guid id, string title, string description, Guid clientId, Guid freelancerId, decimal totalCost, User client, User freelancer)
        {
            Id = id;
            Title = title;
            Description = description;
            ClientId = clientId;
            FreelancerId = freelancerId;
            TotalCost = totalCost;
            Client = client;
            Freelancer = freelancer;
            Status = ProjectStatus.Created;
            Comments = new List<ProjectComment>();
            Active = true;
            CreatedAt = DateTime.Now;
        }

        public string Title { get; private set; }
        public string Description { get; private set; }
        public Guid ClientId { get; private set; }
        public User Client { get; private set; }
        public Guid FreelancerId { get; private set; }
        public User Freelancer { get; private set; }
        public decimal TotalCost { get; private set; }
        public DateTime? StartedAt { get; private set; }
        public DateTime? FinishedAt { get; private set; }
        public ProjectStatus Status { get; private set; }
        public List<ProjectComment> Comments { get; private set; }

        public void Cancel()
        {
            if (Status == ProjectStatus.InProgress || Status == ProjectStatus.Created)
                Status = ProjectStatus.Cancelled;
        }

        public void Start()
        {
            if (Status == ProjectStatus.Created)
            {
                Status = ProjectStatus.InProgress;
                StartedAt = DateTime.Now;
            }
        }

        public void Finish()
        {
            if (Status == ProjectStatus.PaymentPending)
            {
                Status = ProjectStatus.Finished;
                FinishedAt = DateTime.Now;
            }
        }

        public void Update(string title, string description, decimal totalCost)
        {
            Title = title;
            Description = description;
            TotalCost = totalCost;
        }

        public void SetPaymentPending()
        {
            Status = ProjectStatus.PaymentPending;
            FinishedAt = null;
        }
    }
}
