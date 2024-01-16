using DevFreelaCQRS.Core.Entities;
using DevFreelaCQRS.Core.Repositories;
using MediatR;

namespace DevFreelaCQRS.Application.Commands.CommentCommands.CreateComment
{
    public class CreateProjectCommentCommandHandler : IRequestHandler<CreateProjectCommentCommand, Guid>
    {
        private readonly IProjectCommentRepository _repository;

        public CreateProjectCommentCommandHandler(IProjectCommentRepository repository)
        {
            _repository = repository;
        }

        public async Task<Guid> Handle(CreateProjectCommentCommand request, CancellationToken cancellationToken)
        {
            var projectComment = new ProjectComment(request.Content, request.ProjectId, request.UserId);

            await _repository.AddAsync(projectComment);

            return projectComment.Id;
        }
    }
}
