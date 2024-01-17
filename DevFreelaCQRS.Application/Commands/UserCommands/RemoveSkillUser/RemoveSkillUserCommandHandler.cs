using DevFreelaCQRS.Core.Repositories;
using MediatR;

namespace DevFreelaCQRS.Application.Commands.UserCommands.RemoveSkillToUser
{
    public class RemoveSkillUserCommandHandler : IRequestHandler<RemoveSkillUserCommand, Unit>
    {
        private readonly IUserRepository _userRepository;
        private readonly ISkillRepository _skillRepository;

        public RemoveSkillUserCommandHandler(IUserRepository userRepository, ISkillRepository skillRepository)
        {
            _userRepository = userRepository;
            _skillRepository = skillRepository;
        }

        public async Task<Unit> Handle(RemoveSkillUserCommand request, CancellationToken cancellationToken)
        {
            if (await _userRepository.GetByIdAsync(request.UserId) == null || await _skillRepository.GetByIdAsync(request.SkillId) == null)
                return Unit.Value;

            var user = await _userRepository.GetByIdAsync(request.UserId);
            var userSkill = user.Skills.FirstOrDefault(x => x.UserId == request.UserId && x.SkillId == request.SkillId);

            if (userSkill == null)
                return Unit.Value;

            user.Skills.Remove(userSkill);
            await _userRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
