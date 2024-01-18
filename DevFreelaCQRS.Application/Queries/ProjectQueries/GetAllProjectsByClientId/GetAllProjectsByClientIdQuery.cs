using DevFreelaCQRS.Application.ViewModels;
using MediatR;

namespace DevFreelaCQRS.Application.Queries.ProjectQueries.GetAllProjectsByClientId
{
    public class GetAllProjectsByClientIdQuery : IRequest<List<ProjectViewModel>>
    {
        public GetAllProjectsByClientIdQuery(Guid clientId) 
        { 
            ClientId = clientId;
        }

        public Guid ClientId { get; set; }
    }
}
