using MediatorR.App;
using MediatorR.Models;
using MediatorR.Notification;
using MediatorR.Repository.Interface;
using MediatorR.Services.Interface;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace MediatorR.Services.Implementation
{
    public class RegisterUserService : IRegisterUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMediator _mediator;

        public RegisterUserService(IUserRepository userRepository, IMediator mediator)
        {
            _userRepository = userRepository;
            _mediator = mediator;
        }
        public async Task<Guid> Registeruser(Users user)
        {
            if (await _userRepository.IsUserNameTaken(user.UserName) || await _userRepository.IsEmailTaken(user.Email))
            {
                throw new InvalidOperationException("Username or email is already taken");
            }

            user.Password = PasswordHash.HashPassword(user.Password);

            var userId =  await _userRepository.AddUser(user);

            await _mediator.Publish(new UserRegisteredNotification { UserName = user.UserName });
            return userId;
        }
    }
}
