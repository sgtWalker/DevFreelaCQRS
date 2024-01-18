using DevFreelaCQRS.Application.ViewModels;
using MediatR;

namespace DevFreelaCQRS.Application.Queries.ProjectQueries.GetAllProjectsByTitle
{
    public class GetAllProjectsByTitleQuery : IRequest<List<ProjectViewModel>>
    {
        public GetAllProjectsByTitleQuery(string title) 
        {
            Title = title;
        }

        public string Title { get; set; }
    }
}
