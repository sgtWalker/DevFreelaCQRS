using DevFreelaCQRS.Application.ViewModels;
using MediatR;

namespace DevFreelaCQRS.Application.Queries.UserQueries.GetUserSkills
{
    public class GetUserSkillsQuery : IRequest<UserSkillsViewModel>
    {
        public GetUserSkillsQuery(Guid userId)
        {
            UserId = userId;
        }

        public Guid UserId { get; set; }
    }
}
