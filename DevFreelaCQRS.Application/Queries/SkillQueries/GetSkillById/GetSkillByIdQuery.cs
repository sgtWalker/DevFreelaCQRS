using DevFreelaCQRS.Application.ViewModels;
using MediatR;

namespace DevFreelaCQRS.Application.Queries.SkillQueries.GetSkillById
{
    public class GetSkillByIdQuery : IRequest<SkillViewModel>
    {
        public GetSkillByIdQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
