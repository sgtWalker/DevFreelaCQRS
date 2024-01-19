using DevFreelaCQRS.Application.ViewModels;
using MediatR;

namespace DevFreelaCQRS.Application.Queries.ProjectQueries.GetProjectsByClientId
{
    public class GetProjectsByClientIdQuery : IRequest<List<ProjectViewModel>>
    {
        public GetProjectsByClientIdQuery(Guid clientId) 
        { 
            ClientId = clientId;
        }

        public Guid ClientId { get; set; }
    }
}
