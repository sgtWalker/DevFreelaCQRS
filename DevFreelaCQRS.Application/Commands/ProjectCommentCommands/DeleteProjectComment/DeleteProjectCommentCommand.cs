using MediatR;

namespace DevFreelaCQRS.Application.Commands.ProjectCommentCommands.DeleteProjectComment
{
    public class DeleteProjectCommentCommand : IRequest<Unit>
    {
        public DeleteProjectCommentCommand(Guid id) 
        { 
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
