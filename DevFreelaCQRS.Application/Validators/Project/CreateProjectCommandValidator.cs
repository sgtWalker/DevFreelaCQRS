using DevFreelaCQRS.Application.Commands.ProjectCommands.CreateProject;
using FluentValidation;

namespace DevFreelaCQRS.Application.Validators.Project
{
    public class CreateProjectCommandValidator : AbstractValidator<CreateProjectCommand>
    {
        public CreateProjectCommandValidator()  
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

            RuleFor(p => p.ClientId)
                .NotEmpty()
                .WithMessage("O clientId é obrigatório.");

            RuleFor(p => p.ClientId)
                .Must(ValidatorsHelper.IsValidGuid)
                .WithMessage("O clientId é inválido.");

            RuleFor(p => p.FreelancerId)
                .NotEmpty()
                .WithMessage("O freelancerId é obrigatório.");

            RuleFor(p => p.FreelancerId)
                .Must(ValidatorsHelper.IsValidGuid)
                .WithMessage("O freelancerId é inválido.");            
        }
    }
}
