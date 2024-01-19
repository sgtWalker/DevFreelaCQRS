using DevFreelaCQRS.Application.ViewModels;
using MediatR;

namespace DevFreelaCQRS.Application.Queries.ProjectCommentQueries.GetProjectCommentsByProjectId
{
    public class GetProjectCommentsByProjectIdQuery : IRequest<List<ProjectCommentDetailsViewModel>>
    {
        public GetProjectCommentsByProjectIdQuery(Guid projectId)
        {
            ProjectId = projectId;
        }

        public Guid ProjectId { get; set; }
    }
}
