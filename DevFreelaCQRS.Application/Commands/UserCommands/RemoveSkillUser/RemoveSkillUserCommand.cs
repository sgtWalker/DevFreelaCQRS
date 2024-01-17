using MediatR;

namespace DevFreelaCQRS.Application.Commands.UserCommands.RemoveSkillToUser
{
    public class RemoveSkillUserCommand : IRequest<Unit>
    {
        public RemoveSkillUserCommand(Guid userId, Guid skillId)
        {
            UserId = userId;
            SkillId = skillId;
        }

        public Guid UserId { get; set; }
        public Guid SkillId { get; set; }
    }
}
