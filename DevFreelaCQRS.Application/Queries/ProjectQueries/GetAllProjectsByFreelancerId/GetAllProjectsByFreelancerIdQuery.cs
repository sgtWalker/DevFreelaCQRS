using DevFreelaCQRS.Application.ViewModels;
using MediatR;

namespace DevFreelaCQRS.Application.Queries.ProjectQueries.GetAllProjectsByFreelancerId
{
    public class GetAllProjectsByFreelancerIdQuery : IRequest<List<ProjectViewModel>>
    {
        public GetAllProjectsByFreelancerIdQuery(Guid freelancerId)
        {
            FreelancerId = freelancerId;
        }

        public Guid FreelancerId { get; set; }
    }
}
