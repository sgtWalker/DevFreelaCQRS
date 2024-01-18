using DevFreelaCQRS.Application.ViewModels;
using MediatR;

namespace DevFreelaCQRS.Application.Queries.ProjectQueries.GetAllProjectsByDescription
{
    public class GetAllProjectsByDescriptionQuery : IRequest<List<ProjectViewModel>>
    {
        public GetAllProjectsByDescriptionQuery(string description) 
        { 
            Description = description;
        }

        public string Description { get; set; }
    }
}
