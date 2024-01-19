using DevFreelaCQRS.Application.ViewModels;
using MediatR;

namespace DevFreelaCQRS.Application.Queries.CommentQueries.GetProjectCommentById
{
    public class GetProjectCommentByIdQuery : IRequest<ProjectCommentDetailsViewModel>
    {
        public GetProjectCommentByIdQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
