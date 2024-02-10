using DevFreelaCQRS.Application.ViewModels;
using DevFreelaCQRS.Core.Repositories;
using MediatR;

namespace DevFreelaCQRS.Application.Queries.ProjectQueries.GetProjectDetailsById
{
    public class GetProjectDetailsByIdQueryHandler : IRequestHandler<GetProjectDetailsByIdQuery, ProjectDetailsViewModel>
    {
        private readonly IProjectRepository _repository;

        public GetProjectDetailsByIdQueryHandler(IProjectRepository repository)
        {
            _repository = repository;
        }

        public async Task<ProjectDetailsViewModel> Handle(GetProjectDetailsByIdQuery request, CancellationToken cancellationToken)
        {
            var projectDetails = await _repository.GetDetailsByIdAsync(request.Id);

            if (projectDetails == null)
                return null;

            return new ProjectDetailsViewModel(
                projectDetails.Id,
                projectDetails.Title,
                projectDetails.Description,
                projectDetails.StartedAt,
                projectDetails.FinishedAt,
                projectDetails.TotalCost,
                projectDetails.Status,
                projectDetails.Client.FullName,
                projectDetails.Freelancer.FullName
            );
        }
    }
}
