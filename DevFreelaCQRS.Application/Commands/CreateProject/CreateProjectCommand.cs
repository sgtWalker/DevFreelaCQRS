using MediatR;

namespace DevFreelaCQRS.Application.Commands.CreateProject
{
    public class CreateProjectCommand : IRequest<Guid>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid ClientId { get; set; }
        public Guid FreelancerId { get; set; }
        public decimal TotalCost { get; set; }
    }
}
