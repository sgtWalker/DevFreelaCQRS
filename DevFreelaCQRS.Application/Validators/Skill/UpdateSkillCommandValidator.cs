using DevFreelaCQRS.Application.Commands.SkillCommands.UpdateSkill;
using FluentValidation;

namespace DevFreelaCQRS.Application.Validators.Skill
{
    public class UpdateSkillCommandValidator : AbstractValidator<UpdateSkillCommand>
    {
        public UpdateSkillCommandValidator() 
        {
            RuleFor(s => s.Description)
               .NotEmpty()
               .WithMessage("A descrição da habilidade é obrigatória.");

            RuleFor(s => s.Description)
                .MaximumLength(255)
                .WithMessage("O tamanho máximo para a descrição da habilidade é de 255 caracteres.");
        }
    }
}
