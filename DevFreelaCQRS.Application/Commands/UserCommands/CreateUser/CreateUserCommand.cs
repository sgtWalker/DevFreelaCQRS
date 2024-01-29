using MediatR;

namespace DevFreelaCQRS.Application.Commands.UserCommands.CreateUser
{
    public class CreateUserCommand : IRequest<Guid>
    {
        public CreateUserCommand(string fullName, string email, DateTime birthDate)
        {
            FullName = fullName;
            Email = email;
            BirthDate = birthDate;
        }

        public string FullName { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
