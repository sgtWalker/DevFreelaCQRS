using DevFreelaCQRS.Application.ViewModels;
using DevFreelaCQRS.Core.Repositories;
using MediatR;

namespace DevFreelaCQRS.Application.Queries.ProjectQueries.GetProjectById
{
    public class GetProjectByIdQueryHandler : IRequestHandler<GetProjectByIdQuery, ProjectViewModel>
    {
        private readonly IProjectRepository _repository;

        public GetProjectByIdQueryHandler(IProjectRepository repository)
        {
            _repository = repository;
        }

        public async Task<ProjectViewModel> Handle(GetProjectByIdQuery request, CancellationToken cancellationToken)
        {
            var project = await _repository.GetByIdAsync(request.Id);

            if (project == null)
                return null;

            return new ProjectViewModel(
                project.Id,
                project.Title,
                project.CreatedAt
                );
        }
    }
}
