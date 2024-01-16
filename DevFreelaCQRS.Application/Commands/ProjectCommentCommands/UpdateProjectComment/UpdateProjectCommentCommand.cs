using MediatR;

namespace DevFreelaCQRS.Application.Commands.ProjectCommentCommands.UpdateProjectComment
{
    public class UpdateProjectCommentCommand : IRequest<Unit>
    {
        public UpdateProjectCommentCommand(Guid id, string content)
        {
            Id = id;
            Content = content;
        }

        public Guid Id { get; set; }
        public string Content { get; set; }
    }
}
