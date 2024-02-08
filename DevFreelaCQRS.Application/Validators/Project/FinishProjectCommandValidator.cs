using DevFreelaCQRS.Application.Commands.ProjectCommands.FinishProject;
using FluentValidation;

namespace DevFreelaCQRS.Application.Validators.Project
{
    public class FinishProjectCommandValidator : AbstractValidator<FinishProjectCommand>
    {
        public FinishProjectCommandValidator() 
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
