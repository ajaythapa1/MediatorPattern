using FluentValidation;
using MediatorR.Commands;
using MediatorR.Models;
using MediatorR.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace MediatorR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        private readonly IValidator<RegisterUserCommand> _uservalidator;

        public UserController(IMediator mediator, IValidator<RegisterUserCommand> uservalidator)
        {
            _mediator = mediator;
            _uservalidator = uservalidator;
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
                var ressult = _uservalidator.Validate(command);
                if (!ressult.IsValid)
                {
                    return BadRequest(ressult.Errors);
                }
                var userId = await _mediator.Send(command);
                return Ok($"User registered with Id: {userId}");
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
