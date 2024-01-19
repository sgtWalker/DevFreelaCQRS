using DevFreelaCQRS.Application.ViewModels;
using MediatR;

namespace DevFreelaCQRS.Application.Queries.ProjectQueries.GetProjectsByDescription
{
    public class GetProjectsByDescriptionQuery : IRequest<List<ProjectViewModel>>
    {
        public GetProjectsByDescriptionQuery(string description) 
        { 
            Description = description;
        }

        public string Description { get; set; }
    }
}
