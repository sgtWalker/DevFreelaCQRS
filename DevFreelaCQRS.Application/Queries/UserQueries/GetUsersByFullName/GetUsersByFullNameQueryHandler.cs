using DevFreelaCQRS.Application.ViewModels;
using DevFreelaCQRS.Core.Repositories;
using MediatR;

namespace DevFreelaCQRS.Application.Queries.UserQueries.GetUsersByFullName
{
    public class GetUsersByFullNameQueryHandler : IRequestHandler<GetUsersByFullNameQuery, List<UserViewModel>>
    {
        protected readonly IUserRepository _repository;

        public GetUsersByFullNameQueryHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<UserViewModel>> Handle(GetUsersByFullNameQuery request, CancellationToken cancellationToken)
        {
            var users = await _repository.GetUsersByFullNameAsync(request.FullName);

            return users.Select(u => new UserViewModel(u.FullName, u.Email, u.BirthDate)).ToList();
        }
    }
}
