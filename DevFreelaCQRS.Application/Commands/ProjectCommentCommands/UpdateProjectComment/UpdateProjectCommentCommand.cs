using MediatR;

namespace DevFreelaCQRS.Application.Commands.ProjectCommentCommands.UpdateProjectComment
{
    public class UpdateProjectCommentCommand : IRequest<Unit>
    {
        public UpdateProjectCommentCommand(string content)
        {
            Content = content;
        }

        public Guid Id { get; set; }
        public string Content { get; set; }
    }
}
