using DevFreelaCQRS.Core.Entities;
using DevFreelaCQRS.Core.Repositories;
using MediatR;

namespace DevFreelaCQRS.Application.Commands.SkillCommands.CreateSkill
{
    public class CreateSkillCommandHandler : IRequestHandler<CreateSkillCommand, Guid>
    {
        private readonly ISkillRepository _repository;

        public CreateSkillCommandHandler(ISkillRepository repository) 
        { 
            _repository = repository;
        }

        public async Task<Guid> Handle(CreateSkillCommand request, CancellationToken cancellationToken)
        {
            var skill = new Skill(request.Description);

            await _repository.AddAsync(skill);
            await _repository.SaveChangesAsync();

            return skill.Id;
        }
    }
}
