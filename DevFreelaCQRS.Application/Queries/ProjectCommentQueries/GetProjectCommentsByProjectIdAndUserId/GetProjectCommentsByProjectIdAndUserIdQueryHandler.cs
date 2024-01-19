using DevFreelaCQRS.Application.ViewModels;
using DevFreelaCQRS.Core.Repositories;
using MediatR;

namespace DevFreelaCQRS.Application.Queries.ProjectCommentQueries.GetProjectCommentsByProjectIdAndUserId
{
    public class GetProjectCommentsByProjectIdAndUserIdQueryHandler : IRequestHandler<GetProjectCommentsByProjectIdAndUserIdQuery, List<ProjectCommentDetailsViewModel>>
    {
        private readonly IProjectCommentRepository _repository;

        public GetProjectCommentsByProjectIdAndUserIdQueryHandler(IProjectCommentRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<ProjectCommentDetailsViewModel>> Handle(GetProjectCommentsByProjectIdAndUserIdQuery request, CancellationToken cancellationToken)
        {
            var projectComments = await _repository.GetProjectCommentsByProjectIdAndUserIdAsync(request.ProjectId, request.UserId);

            return projectComments.Select(p => new ProjectCommentDetailsViewModel(p.Content, p.Project.Title, p.User.FullName)).ToList();
        }
    }
}
