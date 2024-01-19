using DevFreelaCQRS.Application.ViewModels;
using DevFreelaCQRS.Core.Repositories;
using MediatR;

namespace DevFreelaCQRS.Application.Queries.SkillQueries.GetSkillById
{
    public class GetSkillByIdQueryHandler : IRequestHandler<GetSkillByIdQuery, SkillViewModel>
    {
        private readonly ISkillRepository _repository;

        public GetSkillByIdQueryHandler(ISkillRepository repository)
        {
            _repository = repository;
        }

        public async Task<SkillViewModel> Handle(GetSkillByIdQuery request, CancellationToken cancellationToken)
        {
            var skill = await _repository.GetByIdAsync(request.Id);

            if (skill == null)
                return null;

            return new SkillViewModel(skill.Description);
        }
    }
}
