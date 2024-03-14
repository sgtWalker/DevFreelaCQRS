using DevFreelaCQRS.Core.DTOs;
using DevFreelaCQRS.Core.Enums;
using DevFreelaCQRS.Core.Repositories;
using DevFreelaCQRS.Core.Services;
using MediatR;

namespace DevFreelaCQRS.Application.Commands.ProjectCommands.FinishProject
{
    public class FinishProjectCommandHandler : IRequestHandler<FinishProjectCommand, Unit>
    {
        private readonly IProjectRepository _repository;
        private readonly IPaymentService _paymentService;

        public FinishProjectCommandHandler(IProjectRepository repository, IPaymentService paymentService)
        {
            _repository = repository;
            _paymentService = paymentService;
        }

        public async Task<Unit> Handle(FinishProjectCommand request, CancellationToken cancellationToken)
        {
            var project = await _repository.GetByIdAsync(request.Id);

            if (project == null)
                return Unit.Value;

            project.Finish();

            if (project.Status == ProjectStatus.Finished && project.TotalCost > 0)
                await _paymentService.ProcessPayment(new PaymentInfoDTO(project.Id, "", "", "", "", project.TotalCost));

            await _repository.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
