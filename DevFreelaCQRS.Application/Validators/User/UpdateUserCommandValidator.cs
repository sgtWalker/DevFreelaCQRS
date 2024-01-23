using DevFreelaCQRS.Application.Commands.UserCommands.UpdateUser;
using FluentValidation;

namespace DevFreelaCQRS.Application.Validators.User
{
    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator() 
        {
            RuleFor(u => u.FullName)
                .NotEmpty()
                .WithMessage("Nome é obrigatório.");

            RuleFor(u => u.Email)
                .NotEmpty()
                .WithMessage("Email é obrigatório.");

            RuleFor(u => u.Email)
                .EmailAddress()
                .WithMessage("Email inválido.");

            RuleFor(u => u.BirthDate)
                .NotEmpty()
                .WithMessage("Data de nascimento é obrigatória.");

            RuleFor(u => u.BirthDate)
                .Must(ValidatorsHelper.IsAValidDate)
                .WithMessage("Data de nascimento inválida.");
        }
    }
}
