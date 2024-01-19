using DevFreelaCQRS.Application.ViewModels;
using DevFreelaCQRS.Core.Repositories;
using MediatR;

namespace DevFreelaCQRS.Application.Queries.UserQueries.GetUserByEmail
{
    public class GetUserByEmailQueryHandler : IRequestHandler<GetUserByEmailQuery, UserViewModel>
    {
        protected readonly IUserRepository _repository;
        
        public GetUserByEmailQueryHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<UserViewModel> Handle(GetUserByEmailQuery request, CancellationToken cancellationToken)
        {
            var user = await _repository.GetUserByEmailAsync(request.Email);

            if (user == null)
                return null;

            return new UserViewModel(user.FullName, user.Email, user.BirthDate);
        }
    }
}
