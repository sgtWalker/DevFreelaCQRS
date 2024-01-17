using DevFreelaCQRS.Core.Entities;
using DevFreelaCQRS.Core.Repositories;
using MediatR;

namespace DevFreelaCQRS.Application.Commands.UserCommands.AddSkillToUser
{
    public class AddSkillToUserCommandHandler : IRequestHandler<AddSkillToUserCommand, Unit>
    {
        private readonly IUserRepository _userRepository;
        private readonly ISkillRepository _skillRepository;

        public AddSkillToUserCommandHandler(IUserRepository userRepository, ISkillRepository skillRepository)
        {
            _userRepository = userRepository;
            _skillRepository = skillRepository;
        }

        public async Task<Unit> Handle(AddSkillToUserCommand request, CancellationToken cancellationToken)
        {
            if (await _userRepository.GetByIdAsync(request.UserId) == null || await _skillRepository.GetByIdAsync(request.SkillId) == null)
                return Unit.Value;

            var user = await _userRepository.GetByIdAsync(request.UserId);
            var userSkill = new UserSkill(request.UserId, request.SkillId);

            user.Skills.Add(userSkill);
            await _userRepository.SaveChangesAsync();
            
            return Unit.Value;
        }
    }
}
