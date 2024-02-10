using DevFreelaCQRS.Application.Commands.CommentCommands.CreateComment;
using DevFreelaCQRS.Application.Commands.ProjectCommands.CreateProject;
using DevFreelaCQRS.Application.Commands.ProjectCommands.DeleteProject;
using DevFreelaCQRS.Application.Commands.ProjectCommands.FinishProject;
using DevFreelaCQRS.Application.Commands.ProjectCommands.StartProject;
using DevFreelaCQRS.Application.Commands.ProjectCommands.UpdateProject;
using DevFreelaCQRS.Application.Commands.ProjectCommentCommands.DeleteProjectComment;
using DevFreelaCQRS.Application.Commands.ProjectCommentCommands.UpdateProjectComment;
using DevFreelaCQRS.Application.Queries.CommentQueries.GetProjectCommentById;
using DevFreelaCQRS.Application.Queries.ProjectCommentQueries.GetProjectCommentsByProjectId;
using DevFreelaCQRS.Application.Queries.ProjectCommentQueries.GetProjectCommentsByProjectIdAndUserId;
using DevFreelaCQRS.Application.Queries.ProjectCommentQueries.GetProjectCommentsByUserId;
using DevFreelaCQRS.Application.Queries.ProjectQueries.GetAllProjects;
using DevFreelaCQRS.Application.Queries.ProjectQueries.GetProjectById;
using DevFreelaCQRS.Application.Queries.ProjectQueries.GetProjectDetailsById;
using DevFreelaCQRS.Application.Queries.ProjectQueries.GetProjectsByClientId;
using DevFreelaCQRS.Application.Queries.ProjectQueries.GetProjectsByDescription;
using DevFreelaCQRS.Application.Queries.ProjectQueries.GetProjectsByFreelancerId;
using DevFreelaCQRS.Application.Queries.ProjectQueries.GetProjectsByTitle;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DevFreelaCQRS.API.Controllers
{
    [Route("api/projects")]
    public class ProjectsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProjectsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        #region [Gets]
        [HttpGet]
        [Authorize(Roles = "client, freelancer")]
        public async Task<IActionResult> Get()
        {
            var getAllProjectsQuery = new GetAllProjectsQuery();

            var projects = await _mediator.Send(getAllProjectsQuery);

            return Ok(projects);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "client, freelancer")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var query = new GetProjectByIdQuery(id);

            var project = await _mediator.Send(query);

            if (project == null)
                return NotFound();

            return Ok(project);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "client, freelancer")]
        public async Task<IActionResult> GetDetailsById(Guid id)
        {
            var query = new GetProjectDetailsByIdQuery(id);

            var projectDetails = await _mediator.Send(query);

            if (projectDetails == null)
                return NotFound();

            return Ok(projectDetails);
        }

        [HttpGet("projectsByClient/{clientId}")]
        [Authorize(Roles = "client")]
        public async Task<IActionResult> GetByClientId(Guid clientId)
        {
            var query = new GetProjectsByClientIdQuery(clientId);

            var projects = await _mediator.Send(query);

            if (projects == null)
                return NotFound();

            return Ok(projects);
        }

        [HttpGet("projectsByDescription/{description}")]
        [Authorize(Roles = "client, freelancer")]
        public async Task<IActionResult> GetByDescription(string description)
        {
            var query = new GetProjectsByDescriptionQuery(description);

            var projects = await _mediator.Send(query);

            if (projects == null)
                return NotFound();

            return Ok(projects);
        }

        [HttpGet("projectsByFreelancer/{freelancerId}")]
        [Authorize(Roles = "client, freelancer")]
        public async Task<IActionResult> GetByFreelancerId(Guid freelancerId)
        {
            var query = new GetProjectsByFreelancerIdQuery(freelancerId);

            var projects = await _mediator.Send(query);

            if (projects == null)
                return NotFound();

            return Ok(projects);
        }

        [HttpGet("projectsByTitle/{title}")]
        [Authorize(Roles = "client, freelancer")]
        public async Task<IActionResult> GetByTitle(string title)
        {
            var query = new GetProjectsByTitleQuery(title);

            var projects = await _mediator.Send(query);

            if (projects == null)
                return NotFound();

            return Ok(projects);
        }

        [HttpGet("commentById/{id}")]
        [Authorize(Roles = "client, freelancer")]
        public async Task<IActionResult> GetCommentById(Guid id)
        {
            var query = new GetProjectCommentByIdQuery(id);

            var project = await _mediator.Send(query);

            if (project == null)
                return NotFound();

            return Ok(project);
        }

        [HttpGet("commentsByProjectId/{projectId}")]
        [Authorize(Roles = "client, freelancer")]
        public async Task<IActionResult> GetCommentsByProjectId(Guid projectId)
        {
            var query = new GetProjectCommentsByProjectIdQuery(projectId);

            var projects = await _mediator.Send(query);

            if (projects == null)
                return NotFound();

            return Ok(projects);
        }

        [HttpGet("commentsByProjectIdAndUserId")]
        [Authorize(Roles = "client, freelancer")]
        public async Task<IActionResult> GetCommentsByProjectIdAndUserId(Guid projectId, Guid userId)
        {
            var query = new GetProjectCommentsByProjectIdAndUserIdQuery(projectId, userId);

            var projects = await _mediator.Send(query);

            if (projects == null)
                return NotFound();

            return Ok(projects);
        }

        [HttpGet("commentsByUserId/{userId}")]
        [Authorize(Roles = "client, freelancer")]
        public async Task<IActionResult> GetCommentsByUserId(Guid userId)
        {
            var query = new GetProjectCommentsByUserIdQuery(userId);

            var projects = await _mediator.Send(query);

            if (projects == null)
                return NotFound();

            return Ok(projects);
        }
        #endregion

        #region [Post]
        [HttpPost]
        [Authorize(Roles = "client")]
        public async Task<IActionResult> Post([FromBody] CreateProjectCommand command)
        {
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id }, command);
        }

        [HttpPost("comment")]
        [Authorize(Roles = "client, freelancer")]
        public async Task<IActionResult> PostComment([FromBody] CreateProjectCommentCommand command)
        {
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetCommentById), new { id }, command);
        }
        #endregion

        #region [Puts]
        [HttpPut("{id}")]
        [Authorize(Roles = "client")]
        public async Task<IActionResult> Put(Guid id, [FromBody] UpdateProjectCommand command)
        {
            command.Id = id;
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpPut("cancel/{id}")]
        [Authorize(Roles = "client")]
        public async Task<IActionResult> Cancel(Guid id)
        {
            var command = new StartProjectCommand(id);
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpPut("start/{id}")]
        [Authorize(Roles = "client")]
        public async Task<IActionResult> Start(Guid id)
        {
            var command = new StartProjectCommand(id);
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpPut("finish/{id}")]
        [Authorize(Roles = "client")]
        public async Task<IActionResult> Finish(Guid id)
        {
            var command = new FinishProjectCommand(id);
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpPut("updateComment/{id}")]
        [Authorize(Roles = "client, freelancer")]
        public async Task<IActionResult> UpdateComment(Guid id, [FromBody] UpdateProjectCommentCommand command)
        {
            command.Id = id;
            await _mediator.Send(command);

            return NoContent();
        }
        #endregion

        #region [Deletes]
        [HttpDelete("{id}")]
        [Authorize(Roles = "client")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteProjectCommand(id);
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("deleteComment/{id}")]
        [Authorize(Roles = "client, freelancer")]
        public async Task<IActionResult> DeleteComment(Guid id)
        {
            var command = new DeleteProjectCommentCommand(id);
            await _mediator.Send(command);

            return NoContent();
        }
        #endregion
    }
}
