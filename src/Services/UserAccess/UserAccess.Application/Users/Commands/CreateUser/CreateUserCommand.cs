using System.Text.RegularExpressions;

namespace UserAccess.Application.Users.Commands.CreateUser
{
    public record CreateUserCommand(UserAddDto User) : ICommand<CreateUserResult>;
    public record CreateUserResult(Guid Id);
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(u => u.User.Email)
                .NotEmpty().WithMessage("Email cannot be empty.")
                .EmailAddress().WithMessage("Invalid email format.");

            RuleFor(u => u.User.UserName)
                .NotEmpty().WithMessage("Username cannot be empty.")
                .Length(3, 50).WithMessage("Username must be between 3 and 50 characters.");


            RuleFor(u => u.User.AccountId)
                .NotEmpty().WithMessage("Account ID cannot be empty.");
        }
    }
}
