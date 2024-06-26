﻿using MediatR;

namespace DevFreelaCQRS.Application.Commands.UserCommands.UpdateUser
{
    public class UpdateUserCommand : IRequest<Unit>
    {
        public UpdateUserCommand(string fullName, string email, DateTime birthDate)
        {
            FullName = fullName;
            Email = email;
            BirthDate = birthDate;
        }

        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
