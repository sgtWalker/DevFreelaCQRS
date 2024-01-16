using MediatR;

namespace DevFreelaCQRS.Application.Commands.CommentCommands.CreateComment
{
    public class CreateProjectCommentCommand : IRequest<Guid>
    {
        public CreateProjectCommentCommand(string content, Guid projectId, Guid userId)
        {
            Content = content;
            ProjectId = projectId;
            UserId = userId;
        }

        public string Content { get; set; }
        public Guid ProjectId { get; set; }
        public Guid UserId { get; set; }
    }
}
