using DevFreelaCQRS.Application.ViewModels;
using MediatR;

namespace DevFreelaCQRS.Application.Queries.ProjectQueries.GetProjectsByTitle
{
    public class GetProjectsByTitleQuery : IRequest<List<ProjectViewModel>>
    {
        public GetProjectsByTitleQuery(string title) 
        {
            Title = title;
        }

        public string Title { get; set; }
    }
}
