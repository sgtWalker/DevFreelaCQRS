using DevFreelaCQRS.Core.Repositories;
using MediatR;

namespace DevFreelaCQRS.Application.Commands.ProjectCommands.CancelProject
{
    public class CancelProjectCommandHandler : IRequestHandler<CancelProjectCommand, Unit>
    {
        private readonly IProjectRepository _repository;

        public CancelProjectCommandHandler(IProjectRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(CancelProjectCommand request, CancellationToken cancellationToken)
        {
            var project = await _repository.GetByIdAsync(request.Id);

            if (project == null)
                return Unit.Value;

            project.Cancel();
            await _repository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
