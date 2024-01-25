using DevFreelaCQRS.Application.Commands.SkillCommands.DeleteSkill;
using FluentValidation;

namespace DevFreelaCQRS.Application.Validators.Skill
{
    public class DeleteSkillCommandValidator : AbstractValidator<DeleteSkillCommand>
    {
        public DeleteSkillCommandValidator() 
        {
            RuleFor(u => u.Id)
               .NotEmpty()
               .WithMessage("Id é obrigatório.");

            RuleFor(u => u.Id)
                .Must(ValidatorsHelper.IsInvalidGuid)
                .WithMessage("Id é inválido.");
        }
    }
}
