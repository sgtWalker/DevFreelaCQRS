using DevFreelaCQRS.Application.Commands.CommentCommands.CreateComment;
using FluentValidation;

namespace DevFreelaCQRS.Application.Validators.ProjectComment
{
    public class CreateProjectCommentCommandValidator : AbstractValidator<CreateProjectCommentCommand>
    {
        public CreateProjectCommentCommandValidator() 
        {
            RuleFor(p => p.Content)
                .NotEmpty()
                .WithMessage("Comentário é obrigatório");

            RuleFor(p => p.Content)
                .MaximumLength(500)
                .WithMessage("O tamanho máximo do comentário é de 500 caracteres.");

            RuleFor(p => p.ProjectId)
                .NotEmpty()
                .WithMessage("ProjectId é obrigatório.");

            RuleFor(p => p.ProjectId)
                .Must(ValidatorsHelper.IsValidGuid)
                .WithMessage("ProjectId inválido.");

            RuleFor(p => p.UserId)
                .NotEmpty()
                .WithMessage("UserId é obrigatório.");

            RuleFor(p => p.UserId)
                .Must(ValidatorsHelper.IsValidGuid)
                .WithMessage("UserId inválido.");

        }
    }
}
