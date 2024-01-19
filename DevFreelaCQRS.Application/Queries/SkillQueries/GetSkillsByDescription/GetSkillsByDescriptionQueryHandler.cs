using DevFreelaCQRS.Application.ViewModels;
using DevFreelaCQRS.Core.Repositories;
using MediatR;

namespace DevFreelaCQRS.Application.Queries.SkillQueries.GetSkillsByDescription
{
    public class GetSkillsByDescriptionQueryHandler : IRequestHandler<GetSkillsByDescriptionQuery, List<SkillViewModel>>
    {
        private readonly ISkillRepository _repository;

        public GetSkillsByDescriptionQueryHandler(ISkillRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<SkillViewModel>> Handle(GetSkillsByDescriptionQuery request, CancellationToken cancellationToken)
        {
            var skills = await _repository.GetSkillsByDescriptionAsync(request.Description);

            return skills.Select(s => new SkillViewModel(s.Description)).ToList();
        }
    }
}
