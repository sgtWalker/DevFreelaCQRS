﻿using DevFreelaCQRS.Application.Commands.UserCommands.CreateUser;
using FluentValidation;

namespace DevFreelaCQRS.Application.Validators.User
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator() 
        {
            RuleFor(u => u.FullName)
                .NotEmpty()
                .WithMessage("Nome é obrigatório.");

            RuleFor(u => u.Email)
                .NotEmpty()
                .WithMessage("Email é obrigatório.");

            RuleFor(u => u.Email)
                .EmailAddress()
                .WithMessage("Email inválido.");

            RuleFor(u => u.BirthDate)
                .NotEmpty()
                .WithMessage("Data de nascimento é obrigatória.");

            RuleFor(u => u.BirthDate)
                .Must(ValidatorsHelper.IsAValidDate)
                .WithMessage("Data de nascimento inválida.");

            RuleFor(u => u.Password)
                .Must(ValidatorsHelper.IsPasswordValid)
                .WithMessage("Senha deve conter pelo menos 8 caracteres, um número, uma letra maiúscula, uma minúscula e um caractere especial.");
        }
    }
}
