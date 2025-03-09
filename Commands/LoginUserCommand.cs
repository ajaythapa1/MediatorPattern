using MediatorR.Dtos;
using MediatorR.Models;
using MediatR;

namespace MediatorR.Commands
{
    public record LoginUserCommand(LoginDto loginDto) : IRequest<string>
    {
    }
}
