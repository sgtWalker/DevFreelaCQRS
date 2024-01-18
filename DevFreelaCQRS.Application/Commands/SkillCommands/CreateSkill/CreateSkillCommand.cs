using MediatR;

namespace DevFreelaCQRS.Application.Commands.SkillCommands.CreateSkill
{
    public class CreateSkillCommand : IRequest<Guid>
    {
        public CreateSkillCommand(string description) 
        {
            Description = description;
        } 

        public string Description { get; set; }
    }
}
