using MediatR;

namespace DevFreelaCQRS.Application.Commands.ProjectCommands.FinishProject
{
    public class FinishProjectCommand : IRequest<Unit>
    {
        public FinishProjectCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }
    }
}
