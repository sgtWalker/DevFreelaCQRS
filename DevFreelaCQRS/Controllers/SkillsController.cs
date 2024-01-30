using DevFreelaCQRS.Application.Commands.SkillCommands.CreateSkill;
using DevFreelaCQRS.Application.Commands.SkillCommands.DeleteSkill;
using DevFreelaCQRS.Application.Commands.SkillCommands.UpdateSkill;
using DevFreelaCQRS.Application.Queries.SkillQueries.GetAllSkills;
using DevFreelaCQRS.Application.Queries.SkillQueries.GetSkillById;
using DevFreelaCQRS.Application.Queries.SkillQueries.GetSkillsByDescription;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DevFreelaCQRS.API.Controllers
{
    [Route("api/skills")]
    [Authorize]
    public class SkillsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SkillsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        #region [Gets]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var query = new GetAllSkillsQuery();
            var skills = await _mediator.Send(query);

            return Ok(skills);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var query = new GetSkillByIdQuery(id);

            var skill = await _mediator.Send(query);

            if (skill == null)
                return NotFound();

            return Ok(skill);
        }

        [HttpGet("skillsByDescription/{description}")]
        public async Task<IActionResult> GetByDescription(string description)
        {
            var query = new GetSkillsByDescriptionQuery(description);
            var skills = await _mediator.Send(query);

            if (skills == null)
                return NotFound();

            return Ok(skills);
        }
        #endregion

        #region [Posts]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateSkillCommand command)
        {
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id }, command);
        }
        #endregion

        #region [Puts]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] UpdateSkillCommand command)
        {
            command.Id = id;
            await _mediator.Send(command);

            return NoContent();
        }
        #endregion

        #region [Delete]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteSkillCommand(id);
            await _mediator.Send(command);

            return NoContent();
        }
        #endregion
    }
}
