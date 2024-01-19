using DevFreelaCQRS.Application.ViewModels;
using DevFreelaCQRS.Core.Repositories;
using MediatR;

namespace DevFreelaCQRS.Application.Queries.ProjectCommentQueries.GetProjectCommentsByProjectId
{
    public class GetProjectCommentsByProjectIdQueryHandler : IRequestHandler<GetProjectCommentsByProjectIdQuery, List<ProjectCommentDetailsViewModel>>
    {
        private readonly IProjectCommentRepository _repository;

        public GetProjectCommentsByProjectIdQueryHandler(IProjectCommentRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<ProjectCommentDetailsViewModel>> Handle(GetProjectCommentsByProjectIdQuery request, CancellationToken cancellationToken)
        {
            var projectComments = await _repository.GetProjectCommentsByProjectIdAsync(request.ProjectId);

            return projectComments.Select(p => new ProjectCommentDetailsViewModel(p.Content, p.Project.Title, p.User.FullName)).ToList();
        }
    }
}
