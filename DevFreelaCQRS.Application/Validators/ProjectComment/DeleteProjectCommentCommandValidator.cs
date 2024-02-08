using DevFreelaCQRS.Application.Commands.ProjectCommentCommands.DeleteProjectComment;
using FluentValidation;

namespace DevFreelaCQRS.Application.Validators.ProjectComment
{
    public class DeleteProjectCommentCommandValidator : AbstractValidator<DeleteProjectCommentCommand>
    {
        public DeleteProjectCommentCommandValidator() 
        {
            RuleFor(p => p.Id)
                .NotEmpty()
                .WithMessage("Id é obrigatório.");

            RuleFor(p => p.Id)
                .Must(ValidatorsHelper.IsValidGuid)
                .WithMessage("Id inválido.");
        }
    }
}
