using DevFreelaCQRS.Application.ViewModels;
using DevFreelaCQRS.Core.Repositories;
using MediatR;

namespace DevFreelaCQRS.Application.Queries.ProjectQueries.GetProjectsByDescription
{
    public class GetProjectsByDescriptionQueryHandler : IRequestHandler<GetProjectsByDescriptionQuery, List<ProjectViewModel>>
    {
        private readonly IProjectRepository _repository;

        public GetProjectsByDescriptionQueryHandler(IProjectRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<ProjectViewModel>> Handle(GetProjectsByDescriptionQuery request, CancellationToken cancellationToken)
        {
            var projects = await _repository.GetAllByDescriptionAsync(request.Description);

            return projects.Select(p => new ProjectViewModel(p.Id, p.Title, p.CreatedAt)).ToList();
        }
    }
}
