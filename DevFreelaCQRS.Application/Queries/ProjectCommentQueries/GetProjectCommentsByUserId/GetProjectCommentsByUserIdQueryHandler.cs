using DevFreelaCQRS.Application.ViewModels;
using DevFreelaCQRS.Core.Repositories;
using MediatR;

namespace DevFreelaCQRS.Application.Queries.ProjectCommentQueries.GetProjectCommentsByUserId
{
    public class GetProjectCommentsByUserIdQueryHandler : IRequestHandler<GetProjectCommentsByUserIdQuery, List<ProjectCommentDetailsViewModel>>
    {
        protected readonly IProjectCommentRepository _repository;

        public GetProjectCommentsByUserIdQueryHandler(IProjectCommentRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<ProjectCommentDetailsViewModel>> Handle(GetProjectCommentsByUserIdQuery request, CancellationToken cancellationToken)
        {
            var projectComments = await _repository.GetProjectCommentsByUserIdAsync(request.UserId);

            return projectComments.Select(p => new ProjectCommentDetailsViewModel(p.Content, p.Project.Title, p.User.FullName)).ToList();
        }
    }
}
