using DevFreelaCQRS.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreelaCQRS.Application.Commands.ProjectCommentCommands.UpdateProjectComment
{
    public class UpdateProjectCommentCommandHandler : IRequestHandler<UpdateProjectCommentCommand, Unit>
    {
        protected readonly IProjectCommentRepository _repository;

        public UpdateProjectCommentCommandHandler(IProjectCommentRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateProjectCommentCommand request, CancellationToken cancellationToken)
        {
            var projectComment = await _repository.GetByIdAsync(request.Id);

            if (projectComment == null)
                return Unit.Value;

            projectComment.Update(request.Content);
            await _repository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
