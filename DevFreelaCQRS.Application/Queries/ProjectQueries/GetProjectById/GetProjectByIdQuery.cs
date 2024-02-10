using DevFreelaCQRS.Application.ViewModels;
using MediatR;

namespace DevFreelaCQRS.Application.Queries.ProjectQueries.GetProjectById
{
    public class GetProjectByIdQuery : IRequest<ProjectViewModel>
    {
        public GetProjectByIdQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }
    }
}
