using DevFreelaCQRS.Application.ViewModels;
using DevFreelaCQRS.Core.Repositories;
using MediatR;

namespace DevFreelaCQRS.Application.Queries.ProjectQueries.GetAllProjectsByDescription
{
    public class GetAllProjectsByDescriptionQueryHandler : IRequestHandler<GetAllProjectsByDescriptionQuery, List<ProjectViewModel>>
    {
        private readonly IProjectRepository _repository;

        public GetAllProjectsByDescriptionQueryHandler(IProjectRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<ProjectViewModel>> Handle(GetAllProjectsByDescriptionQuery request, CancellationToken cancellationToken)
        {
            var projects = await _repository.GetAllByDescriptionAsync(request.Description);

            return projects.Select(p => new ProjectViewModel(p.Id, p.Title, p.CreatedAt)).ToList();
        }
    }
}
