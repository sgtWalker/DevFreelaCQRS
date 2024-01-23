using DevFreelaCQRS.Application.Commands.UserCommands.CreateUser;
using FluentValidation;

namespace DevFreelaCQRS.Application.Validators.Project
{
    public class CreateProjectCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateProjectCommandValidator() 
        {
        }
    }
}
