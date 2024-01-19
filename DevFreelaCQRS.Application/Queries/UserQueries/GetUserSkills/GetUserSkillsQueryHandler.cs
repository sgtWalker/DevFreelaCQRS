using DevFreelaCQRS.Application.ViewModels;
using DevFreelaCQRS.Core.Entities;
using DevFreelaCQRS.Core.Repositories;
using MediatR;

namespace DevFreelaCQRS.Application.Queries.UserQueries.GetUserSkills
{
    public class GetUserSkillsQueryHandler : IRequestHandler<GetUserSkillsQuery, UserSkillsViewModel>
    {
        private readonly IUserRepository _userRepository;
        private readonly ISkillRepository _skillRepository;

        public GetUserSkillsQueryHandler(IUserRepository repository, ISkillRepository skillRepository)
        {
            _userRepository = repository;
            _skillRepository = skillRepository;
        }

        public async Task<UserSkillsViewModel> Handle(GetUserSkillsQuery request, CancellationToken cancellationToken)
        {
            
            var user = await _userRepository.GetUserSkillsAsync(request.UserId);

            if (user == null)
                return null;

            if (user.Skills.Any())
                return new UserSkillsViewModel(user.FullName, user.Email, await GetUserSkills(user.Skills));
            else
                return new UserSkillsViewModel(user.FullName, user.Email, null);
        }

        private async Task<List<SkillViewModel>> GetUserSkills(List<UserSkill> userSkills)
        {
            var skills = new List<SkillViewModel>();

            foreach (var userSkill in userSkills)
            {
                var skill = await _skillRepository.GetByIdAsync(userSkill.SkillId);

                if (skill == null)
                    continue;

                skills.Add(new SkillViewModel(skill.Description));
            }

            return skills;
        }
    }
}
