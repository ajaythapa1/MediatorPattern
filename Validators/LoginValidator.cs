using FluentValidation;
using MediatorR.Commands;

namespace MediatorR.Validators
{
    public class LoginValidator : AbstractValidator<LoginUserCommand>
    {
        public LoginValidator()
        {
            RuleFor(x => x.loginDto.Email)
                .NotEmpty().WithMessage("Email is required")
                .EmailAddress().WithMessage("Email is not in correct format");

            RuleFor(x => x.loginDto.Password)
                .NotEmpty().WithMessage("Password is required");
        }
    }
}
