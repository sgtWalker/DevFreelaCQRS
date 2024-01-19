using DevFreelaCQRS.Application.ViewModels;
using MediatR;

namespace DevFreelaCQRS.Application.Queries.UserQueries.GetUsersByFullName
{
    public class GetUsersByFullNameQuery : IRequest<List<UserViewModel>>
    {
        public GetUsersByFullNameQuery(string fullName)
        {
            FullName = fullName;
        }

        public string FullName { get; set; }
    }
}
