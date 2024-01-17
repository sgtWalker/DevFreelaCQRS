using DevFreelaCQRS.Core.Repositories;
using MediatR;

namespace DevFreelaCQRS.Application.Commands.SkillCommands.UpdateSkill
{
    public class UpdateSkillCommandHandler : IRequestHandler<UpdateSkillCommand, Unit>
    {
        private readonly ISkillRepository _repository;

        public UpdateSkillCommandHandler(ISkillRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateSkillCommand request, CancellationToken cancellationToken)
        {
            var skill = await _repository.GetByIdAsync(request.Id);

            if (skill == null)
                return Unit.Value;

            skill.Update(request.Description);
            await _repository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
