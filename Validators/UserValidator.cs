using FluentValidation;
using MediatorR.Commands;
using MediatorR.Models;

namespace MediatorR.Validators
{
    public class UserValidator : AbstractValidator<RegisterUserCommand>
    {
        public UserValidator()
        {
            RuleFor(u => u.user.FirstName)
                .NotEmpty().WithMessage("Username is required")
                .MinimumLength(3).WithMessage("Username must be at least 3 character long");

            RuleFor(u => u.user.Email)
                .NotEmpty().WithMessage("Email is required")
                .EmailAddress().WithMessage("Invalid email format");

            RuleFor(u => u.user.FirstName)
                .NotEmpty().WithMessage("First Name is required");

            RuleFor(u => u.user.LastName)
                .NotEmpty().WithMessage("Last Name is required");

            RuleFor(u => u.user.Password)
                .NotEmpty().WithMessage("Password is required")
                .MinimumLength(8).WithMessage("Password must be at least 8 character long")
                .Matches("[A-Z]").WithMessage("Password must contain at least one Upper Character")
                .Matches("[a-z]").WithMessage("Password must contain at least one lower Character")
                .Matches("[0-9]").WithMessage("Password must contain at least one number")
                .Matches("[^a-zA-Z0-9]").WithMessage("Password must contain at least one Special Character");

        }
    }
}
