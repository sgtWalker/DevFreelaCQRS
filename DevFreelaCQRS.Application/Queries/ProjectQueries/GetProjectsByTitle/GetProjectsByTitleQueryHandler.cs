using DevFreelaCQRS.Application.ViewModels;
using DevFreelaCQRS.Core.Repositories;
using MediatR;

namespace DevFreelaCQRS.Application.Queries.ProjectQueries.GetProjectsByTitle
{
    public class GetProjectsByTitleQueryHandler : IRequestHandler<GetProjectsByTitleQuery, List<ProjectViewModel>>
    {
        private readonly IProjectRepository _repository;

        public GetProjectsByTitleQueryHandler(IProjectRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<ProjectViewModel>> Handle(GetProjectsByTitleQuery request, CancellationToken cancellationToken)
        {
            var projects = await _repository.GetAllByTitleAsync(request.Title);

            return projects.Select(p => new ProjectViewModel(p.Id, p.Title, p.CreatedAt)).ToList();
        }
    }
}
