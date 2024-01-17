using MediatR;

namespace DevFreelaCQRS.Application.Commands.UserCommands.AddSkillToUser
{
    public class AddSkillToUserCommand : IRequest<Unit>
    {
        public AddSkillToUserCommand(Guid userId, Guid skillId)
        {
            UserId = userId;
            SkillId = skillId;
        }

        public Guid UserId { get; set; }
        public Guid SkillId { get; set; }
    }
}
