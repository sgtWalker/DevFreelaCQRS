using DevFreelaCQRS.Core.Repositories;
using MediatR;

namespace DevFreelaCQRS.Application.Commands.SkillCommands.DeleteSkill
{
    public class DeleteSkillCommandHandler : IRequestHandler<DeleteSkillCommand, Unit>
    {
        private readonly ISkillRepository _repository;

        public DeleteSkillCommandHandler(ISkillRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteSkillCommand request, CancellationToken cancellationToken)
        {
            var skill = await _repository.GetByIdAsync(request.Id);

            if (skill == null)
                return Unit.Value;

            skill.Delete();
            await _repository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
