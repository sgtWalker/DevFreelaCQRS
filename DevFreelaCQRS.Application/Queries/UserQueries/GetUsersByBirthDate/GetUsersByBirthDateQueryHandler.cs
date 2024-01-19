using DevFreelaCQRS.Application.ViewModels;
using DevFreelaCQRS.Core.Repositories;
using MediatR;

namespace DevFreelaCQRS.Application.Queries.UserQueries.GetUsersByBirthDate
{
    public class GetUsersByBirthDateQueryHandler : IRequestHandler<GetUsersByBirthDateQuery, List<UserViewModel>>
    {
        protected readonly IUserRepository _repository;

        public GetUsersByBirthDateQueryHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<UserViewModel>> Handle(GetUsersByBirthDateQuery request, CancellationToken cancellationToken)
        {
            var users = await _repository.GetUsersByBirthDate(request.BirthDate);

            return users.Select(u => new UserViewModel(u.FullName, u.Email, u.BirthDate)).ToList();
        }
    }
}
