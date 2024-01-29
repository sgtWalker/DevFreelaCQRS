using DevFreelaCQRS.Application.ViewModels;
using MediatR;

namespace DevFreelaCQRS.Application.Commands.UserCommands.LoginUser
{
    public class LoginUserCommand : IRequest<LoginUserViewModel>
    {
        public LoginUserCommand(string email, string password)
        {
            Email = email;
            Password = password;
        }

        public string Email { get; set; }
        public string Password { get; set; }
    }
}
