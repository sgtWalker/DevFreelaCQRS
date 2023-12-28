using MediatR;

namespace DevFreelaCQRS.Application.Commands.DeleteProject
{
    public class DeleteProjectCommand : IRequest<Unit>
    {
        public DeleteProjectCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }
    }
}
