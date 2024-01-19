using DevFreelaCQRS.Application.ViewModels;
using DevFreelaCQRS.Core.Repositories;
using MediatR;

namespace DevFreelaCQRS.Application.Queries.ProjectQueries.GetProjectsByClientId
{
    public class GetProjectsByClientIdQueryHandler : IRequestHandler<GetProjectsByClientIdQuery, List<ProjectViewModel>>
    {
        protected readonly IProjectRepository _repository;

        public GetProjectsByClientIdQueryHandler(IProjectRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<ProjectViewModel>> Handle(GetProjectsByClientIdQuery request, CancellationToken cancellationToken)
        {
            var projects = await _repository.GetAllByClientIdAsync(request.ClientId);

            return projects.Select(p => new ProjectViewModel(p.Id, p.Title, p.CreatedAt)).ToList();
        }
    }
}
