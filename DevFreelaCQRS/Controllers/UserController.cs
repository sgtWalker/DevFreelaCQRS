using DevFreelaCQRS.Application.Commands.UserCommands.AddSkillToUser;
using DevFreelaCQRS.Application.Commands.UserCommands.CreateUser;
using DevFreelaCQRS.Application.Commands.UserCommands.DeleteUser;
using DevFreelaCQRS.Application.Commands.UserCommands.LoginUser;
using DevFreelaCQRS.Application.Commands.UserCommands.RemoveSkillToUser;
using DevFreelaCQRS.Application.Commands.UserCommands.UpdateUser;
using DevFreelaCQRS.Application.Queries.UserQueries.GetAllUsers;
using DevFreelaCQRS.Application.Queries.UserQueries.GetUserByEmail;
using DevFreelaCQRS.Application.Queries.UserQueries.GetUserById;
using DevFreelaCQRS.Application.Queries.UserQueries.GetUsersByBirthDate;
using DevFreelaCQRS.Application.Queries.UserQueries.GetUsersByFullName;
using DevFreelaCQRS.Application.Queries.UserQueries.GetUserSkills;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DevFreelaCQRS.API.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        #region [Gets]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var query = new GetAllUsersQuery();

            var users = await _mediator.Send(query);

            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var query = new GetUserByIdQuery(id);

            var user = await _mediator.Send(query);

            if (user == null)
                return NotFound();

            return Ok(user);
        }

        [HttpGet("userByEmail/{email}")]
        public async Task<IActionResult> GetByEmail(string email)
        {
            var query = new GetUserByEmailQuery(email);

            var user = await _mediator.Send(query);

            if (user == null)
                return NotFound();

            return Ok(user);
        }

        [HttpGet("usersByBirthDate/{birthDate}")]
        public async Task<IActionResult> GetByBithDate(DateTime birthDate)
        {
            var query = new GetUsersByBirthDateQuery(birthDate);

            var users = await _mediator.Send(query);

            if (users == null)
                return NotFound();

            return Ok(users);
        }

        [HttpGet("usersByFullName/{fullName}")]
        public async Task<IActionResult> GetByFullName(string fullName)
        {
            var query = new GetUsersByFullNameQuery(fullName);

            var users = await _mediator.Send(query);

            if (users == null)
                return NotFound();

            return Ok(users);
        }

        [HttpGet("userSkills/{userId}")]
        public async Task<IActionResult> GetSkills(Guid userId)
        {
            var query = new GetUserSkillsQuery(userId);

            var userSkills = await _mediator.Send(query);

            if (userSkills == null)
                return NotFound();

            return Ok(userSkills);
        }
        #endregion

        #region [Posts]

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateUserCommand command)
        {
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id }, command);
        }

        [HttpPost("addSkill")]
        public async Task<IActionResult> AddSkill(Guid userId, Guid skillId)
        {
            var command = new AddSkillToUserCommand(userId, skillId);
            await _mediator.Send(command);

            return NoContent();
        }
        #endregion

        #region [Puts]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] UpdateUserCommand command)
        {
            command.Id = id;
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpPut("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserCommand command)
        {
            var loginUser = await _mediator.Send(command);

            if (loginUser == null) 
                return BadRequest();

            return Ok(loginUser);
        }
        #endregion

        #region [Deletes]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteUserCommand(id);
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("removeSkill")]
        public async Task<IActionResult> RemoveSkill(Guid userId, Guid skillId)
        {
            var command = new RemoveSkillUserCommand(userId, skillId);
            await _mediator.Send(command);

            return NoContent();
        }
        #endregion
    }
}
