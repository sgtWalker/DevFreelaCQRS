using DevFreelaCQRS.Core.Repositories;
using MediatR;

namespace DevFreelaCQRS.Application.Commands.ProjectCommentCommands.DeleteProjectComment
{
    public class DeleteProjectCommentCommandHandler : IRequestHandler<DeleteProjectCommentCommand, Unit>
    {
        private readonly IProjectCommentRepository _repository;

        public DeleteProjectCommentCommandHandler(IProjectCommentRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteProjectCommentCommand request, CancellationToken cancellationToken)
        {
            var projectComment = await _repository.GetByIdAsync(request.Id);

            if (projectComment == null)
                return Unit.Value;

            projectComment.Delete();
            await _repository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
