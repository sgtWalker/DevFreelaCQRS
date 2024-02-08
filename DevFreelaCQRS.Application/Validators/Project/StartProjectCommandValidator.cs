using DevFreelaCQRS.Application.Commands.ProjectCommands.StartProject;
using FluentValidation;

namespace DevFreelaCQRS.Application.Validators.Project
{
    public class StartProjectCommandValidator : AbstractValidator<StartProjectCommand>
    {
        public StartProjectCommandValidator() 
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
