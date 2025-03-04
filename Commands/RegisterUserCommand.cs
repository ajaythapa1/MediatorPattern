using MediatorR.Models;
using MediatR;

namespace MediatorR.Commands
{
    //marker interface for defining request message
    public record RegisterUserCommand(Users user) : IRequest<Guid>;
}
    
