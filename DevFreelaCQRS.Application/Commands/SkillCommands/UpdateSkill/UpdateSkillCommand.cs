using MediatR;

namespace DevFreelaCQRS.Application.Commands.SkillCommands.UpdateSkill
{
    public class UpdateSkillCommand : IRequest<Unit>
    {
        public UpdateSkillCommand(Guid id, string description)
        {
            Description = description;
        }

        public Guid Id { get; set; }
        public string Description { get; set; }
    }
}
