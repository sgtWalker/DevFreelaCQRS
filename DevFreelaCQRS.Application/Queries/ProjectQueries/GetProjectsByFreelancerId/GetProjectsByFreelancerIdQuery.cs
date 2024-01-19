using DevFreelaCQRS.Application.ViewModels;
using MediatR;

namespace DevFreelaCQRS.Application.Queries.ProjectQueries.GetProjectsByFreelancerId
{
    public class GetProjectsByFreelancerIdQuery : IRequest<List<ProjectViewModel>>
    {
        public GetProjectsByFreelancerIdQuery(Guid freelancerId)
        {
            FreelancerId = freelancerId;
        }

        public Guid FreelancerId { get; set; }
    }
}
