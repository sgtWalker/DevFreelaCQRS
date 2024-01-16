using MediatR;

namespace DevFreelaCQRS.Application.Commands.ProjectCommands.CancelProject
{
    public class CancelProjectCommand : IRequest<Unit>
    {
        public CancelProjectCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
