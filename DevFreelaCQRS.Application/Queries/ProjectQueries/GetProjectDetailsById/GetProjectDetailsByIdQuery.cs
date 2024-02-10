using DevFreelaCQRS.Application.ViewModels;
using MediatR;

namespace DevFreelaCQRS.Application.Queries.ProjectQueries.GetProjectDetailsById
{
    public class GetProjectDetailsByIdQuery : IRequest<ProjectDetailsViewModel>
    {
        public Guid Id { get; set; }

        public GetProjectDetailsByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
