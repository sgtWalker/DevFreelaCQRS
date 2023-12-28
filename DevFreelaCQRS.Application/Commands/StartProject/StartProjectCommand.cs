using MediatR;

namespace DevFreelaCQRS.Application.Commands.StartProject
{
    public class StartProjectCommand : IRequest<Unit>
    {
        public StartProjectCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }
    }
}
