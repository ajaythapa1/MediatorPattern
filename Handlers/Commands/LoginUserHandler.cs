using MediatorR.Commands;
using MediatorR.Services.Interface;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;

namespace MediatorR.Handlers.Commands
{
    public class LoginUserHandler : IRequestHandler<LoginUserCommand , string>
    {
        private readonly ILoginUserService _loginUserService;

        public LoginUserHandler(ILoginUserService loginUserService)
        {
            _loginUserService = loginUserService;
        }

        public Task<string> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var userId = _loginUserService.LoginUser(request.loginDto);
            return userId;
        }
    }
}
