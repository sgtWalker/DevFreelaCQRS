using DevFreelaCQRS.Application.ViewModels;
using DevFreelaCQRS.Core.Repositories;
using MediatR;

namespace DevFreelaCQRS.Application.Queries.CommentQueries.GetProjectCommentById
{
    public class GetProjectCommentByIdQueryHandler : IRequestHandler<GetProjectCommentByIdQuery, ProjectCommentDetailsViewModel>
    {
        private readonly IProjectCommentRepository _repository;

        public GetProjectCommentByIdQueryHandler(IProjectCommentRepository repository)
        {
            _repository = repository;
        }

        public async Task<ProjectCommentDetailsViewModel> Handle(GetProjectCommentByIdQuery request, CancellationToken cancellationToken)
        {
            var projectComment = await _repository.GetByIdAsync(request.Id);

            if (projectComment == null)
                return null;

            return new ProjectCommentDetailsViewModel(projectComment.Content, projectComment.Project.Title, projectComment.User.FullName);
        }
    }
}
