using DevFreelaCQRS.Application.Commands.UserCommands.DeleteUser;
using FluentValidation;

namespace DevFreelaCQRS.Application.Validators.User
{
    public class DeleteUserCommandValidator : AbstractValidator<DeleteUserCommand>
    {
        public DeleteUserCommandValidator() 
        {
            RuleFor(u => u.Id)
                .NotEmpty()
                .WithMessage("Id é obrigatório.");

            RuleFor(u => u.Id)
                .Must(ValidatorsHelper.IsValidGuid)
                .WithMessage("Id é inválido.");
        }
    }
}
