using DevFreelaCQRS.Application.ViewModels;
using DevFreelaCQRS.Core.Repositories;
using MediatR;

namespace DevFreelaCQRS.Application.Queries.ProjectQueries.GetAllProjectsByClientId
{
    public class GetAllProjectsByClientIdQueryHandler : IRequestHandler<GetAllProjectsByClientIdQuery, List<ProjectViewModel>>
    {
        protected readonly IProjectRepository _repository;

        public GetAllProjectsByClientIdQueryHandler(IProjectRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<ProjectViewModel>> Handle(GetAllProjectsByClientIdQuery request, CancellationToken cancellationToken)
        {
            var projects = await _repository.GetAllByClientIdAsync(request.ClientId);

            return projects.Select(p => new ProjectViewModel(p.Id, p.Title, p.CreatedAt)).ToList();
        }
    }
}
