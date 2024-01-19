using DevFreelaCQRS.Application.ViewModels;
using DevFreelaCQRS.Core.Repositories;
using MediatR;

namespace DevFreelaCQRS.Application.Queries.ProjectQueries.GetProjectsByFreelancerId
{
    public class GetProjectsByFreelancerIdQueryHandler : IRequestHandler<GetProjectsByFreelancerIdQuery, List<ProjectViewModel>>
    {
        private readonly IProjectRepository _repository;

        public GetProjectsByFreelancerIdQueryHandler(IProjectRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<ProjectViewModel>> Handle(GetProjectsByFreelancerIdQuery request, CancellationToken cancellationToken)
        {
            var projects = await _repository.GetAllByFreelancerIdAsync(request.FreelancerId);

            return projects.Select(p => new ProjectViewModel(p.Id, p.Title, p.CreatedAt)).ToList();
        }
    }
}
