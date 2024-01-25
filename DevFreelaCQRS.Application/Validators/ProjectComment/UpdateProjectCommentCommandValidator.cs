using DevFreelaCQRS.Application.Commands.ProjectCommentCommands.UpdateProjectComment;
using FluentValidation;

namespace DevFreelaCQRS.Application.Validators.ProjectComment
{
    public class UpdateProjectCommentCommandValidator : AbstractValidator<UpdateProjectCommentCommand>
    {
        public UpdateProjectCommentCommandValidator() 
        {
            RuleFor(p => p.Content)
                .NotEmpty()
                .WithMessage("Comentário é obrigatório");

            RuleFor(p => p.Content)
                .MaximumLength(500)
                .WithMessage("O tamanho máximo do comentário é de 500 caracteres.");
        }
    }
}
