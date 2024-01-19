using DevFreelaCQRS.Application.ViewModels;
using MediatR;

namespace DevFreelaCQRS.Application.Queries.ProjectCommentQueries.GetProjectCommentsByProjectIdAndUserId
{
    public class GetProjectCommentsByProjectIdAndUserIdQuery : IRequest<List<ProjectCommentDetailsViewModel>>
    {
        public GetProjectCommentsByProjectIdAndUserIdQuery(Guid projectId, Guid userId)
        {
            ProjectId = projectId;
            UserId = userId;
        }

        public Guid ProjectId { get; set; }
        public Guid UserId { get; set; }
    }
}
