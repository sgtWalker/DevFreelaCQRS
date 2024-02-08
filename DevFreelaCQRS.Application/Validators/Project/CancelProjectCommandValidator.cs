using DevFreelaCQRS.Application.Commands.ProjectCommands.CancelProject;
using FluentValidation;

namespace DevFreelaCQRS.Application.Validators.Project
{
    public class CancelProjectCommandValidator : AbstractValidator<CancelProjectCommand>
    {
        public CancelProjectCommandValidator() 
        {
            RuleFor(p => p.Id)
                .NotEmpty()
                .WithMessage("O Id é obrigatório.");

            RuleFor(p => p.Id)
                .Must(ValidatorsHelper.IsValidGuid)
                .WithMessage("O Id é inválido.");
        }
    }
}
