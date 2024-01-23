﻿using DevFreelaCQRS.Application.Commands.UserCommands.RemoveSkillToUser;
using FluentValidation;

namespace DevFreelaCQRS.Application.Validators.User
{
    public class RemoveSkillUserCommandValidator : AbstractValidator<RemoveSkillUserCommand>
    {
        public RemoveSkillUserCommandValidator() 
        { 
            RuleFor(u => u.UserId)
                .NotEmpty()
                .WithMessage("userId é obrigatório.");

            RuleFor(u => u.UserId)
                .Must(ValidatorsHelper.IsInvalidGuid)
                .WithMessage("userId é inválido");

            RuleFor(u => u.SkillId)
                .NotEmpty()
                .WithMessage("skillId é obrigatório.");

            RuleFor(u => u.SkillId)
                .Must(ValidatorsHelper.IsInvalidGuid)
                .WithMessage("skillId é inválido");
        }
    }
}
