using MediatorR.Commands;
using MediatorR.Repository.Interface;
using MediatorR.Services.Interface;
using MediatR;

namespace MediatorR.Handlers
{
    public class RequestUserHandeler : IRequestHandler<RegisterUserCommand, Guid>
    {
        private readonly IRegisterUserService _registerUserService;
        public RequestUserHandeler(IRegisterUserService registerUserService) 
        {
            _registerUserService = registerUserService;
        }

        public async Task<Guid> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var userId = await _registerUserService.Registeruser(request.user);
            return userId;
        }
    }
}
