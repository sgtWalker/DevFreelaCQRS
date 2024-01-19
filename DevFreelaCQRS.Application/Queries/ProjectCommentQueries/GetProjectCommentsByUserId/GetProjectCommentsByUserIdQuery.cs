using DevFreelaCQRS.Application.ViewModels;
using MediatR;

namespace DevFreelaCQRS.Application.Queries.ProjectCommentQueries.GetProjectCommentsByUserId
{
    public class GetProjectCommentsByUserIdQuery : IRequest<List<ProjectCommentDetailsViewModel>>
    {
        public GetProjectCommentsByUserIdQuery(Guid userId)
        {
            UserId = userId;
        }

        public Guid UserId { get; set; }
    }
}
