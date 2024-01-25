using DevFreelaCQRS.Application.Commands.ProjectCommands.DeleteProject;
using FluentValidation;

namespace DevFreelaCQRS.Application.Validators.Project
{
    public class DeleteProjectCommandValidator : AbstractValidator<DeleteProjectCommand>
    {
        public DeleteProjectCommandValidator() 
        {
            RuleFor(p => p.Id)
                .NotEmpty()
                .WithMessage("O Id é obrigatório.");

            RuleFor(p => p.Id)
                .Must(ValidatorsHelper.IsInvalidGuid)
                .WithMessage("O Id é inválido.");
        }
    }
}
