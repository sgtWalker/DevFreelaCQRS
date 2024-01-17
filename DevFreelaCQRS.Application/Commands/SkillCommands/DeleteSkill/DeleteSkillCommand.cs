using MediatR;

namespace DevFreelaCQRS.Application.Commands.SkillCommands.DeleteSkill
{
    public class DeleteSkillCommand : IRequest<Unit>
    {
        public DeleteSkillCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
