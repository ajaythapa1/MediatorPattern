using FluentValidation;
using MediatorR.Commands;
using MediatorR.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MediatorR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        private readonly IValidator<RegisterUserCommand> _uservalidator;
        private readonly IValidator<LoginUserCommand> _loginvalidator;

        public UserController(IMediator mediator, IValidator<RegisterUserCommand> uservalidator, IValidator<LoginUserCommand> loginvalidator)
        {
            _mediator = mediator;
            _uservalidator = uservalidator;
            _loginvalidator = loginvalidator;
        }

        [HttpGet("GetAllUser")]
        public async Task<IActionResult> GetAllUser()
        {
            var result = await _mediator.Send(new GetAllUserQuery());
            return Ok(result);
        }

        [HttpPost("Regsister")]
        public async Task<IActionResult> Register([FromBody] RegisterUserCommand command)
        {
            try
            {
                var result = _uservalidator.Validate(command);
                if (!result.IsValid)
                {
                    return BadRequest(result.Errors);
                }
                var userId = await _mediator.Send(command);
                return Ok($"User registered with Id: {userId}");
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginUserCommand command)
        {
            var result = _loginvalidator.Validate(command);
            if (!result.IsValid)
            {
                return BadRequest(result.Errors);
            }

            var token = await _mediator.Send(command);
            return Ok(token);
        }
    }
}
