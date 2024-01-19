using DevFreelaCQRS.Application.ViewModels;
using MediatR;

namespace DevFreelaCQRS.Application.Queries.SkillQueries.GetSkillsByDescription
{
    public class GetSkillsByDescriptionQuery : IRequest<List<SkillViewModel>>
    {
        public GetSkillsByDescriptionQuery(string description) 
        { 
            Description = description;
        }

        public string Description { get; set; }
    }
}
