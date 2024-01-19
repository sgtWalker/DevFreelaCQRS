using DevFreelaCQRS.Application.ViewModels;
using MediatR;

namespace DevFreelaCQRS.Application.Queries.UserQueries.GetUsersByBirthDate
{
    public class GetUsersByBirthDateQuery : IRequest<List<UserViewModel>>
    {
        public GetUsersByBirthDateQuery(DateTime birthDate)
        {
            BirthDate = birthDate;
        }

        public DateTime BirthDate { get; set; }
    }
}
