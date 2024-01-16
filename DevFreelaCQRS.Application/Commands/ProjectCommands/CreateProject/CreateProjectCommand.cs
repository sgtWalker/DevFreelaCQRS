using MediatR;

namespace DevFreelaCQRS.Application.Commands.ProjectCommands.CreateProject
{
    public class CreateProjectCommand : IRequest<Guid>
    {
        public CreateProjectCommand(string title, string description, Guid clientId, Guid freelancerId, decimal totalCost)
        {
            Title = title;
            Description = description;
            ClientId = clientId;
            FreelancerId = freelancerId;
            TotalCost = totalCost;
        }

        public string Title { get; set; }
        public string Description { get; set; }
        public Guid ClientId { get; set; }
        public Guid FreelancerId { get; set; }
        public decimal TotalCost { get; set; }
    }
}
