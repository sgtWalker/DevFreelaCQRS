using DevFreelaCQRS.Application.Commands.ProjectCommands.UpdateProject;
using FluentValidation;

namespace DevFreelaCQRS.Application.Validators.Project
{
    public class UpdateProjectCommandValidator : AbstractValidator<UpdateProjectCommand>
    {
        public UpdateProjectCommandValidator() 
        {
            RuleFor(p => p.Title)
                .NotEmpty()
                .WithMessage("O título do projeto é obrigatório.");

            RuleFor(p => p.Title)
                .MaximumLength(100)
                .WithMessage("O tamanho máximo do título do projeto é de 100 caracteres.");

            RuleFor(p => p.Description)
                .NotEmpty()
                .WithMessage("A descrição do projeto é obrigatória.");
        }
    }
}
