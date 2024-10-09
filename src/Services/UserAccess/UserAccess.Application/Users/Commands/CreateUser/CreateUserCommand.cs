namespace UserAccess.Application.Users.Commands.CreateUser
{
    public record CreateUserCommand(UserAddDto User) : ICommand<CreateUserResult>;
    public record CreateUserResult(Guid Id);
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(x => x.User.UserName).NotEmpty().WithMessage("Name is required");
            RuleFor(x => x.User.Email)
                .NotEmpty()
                .EmailAddress().WithMessage("Invalid email format");
            RuleFor(x => x.User.PhoneNumber).NotEmpty()
                .Matches(@"^\+?[0-9]\d{1,14}$").WithMessage("Invalid phone number format");
        }
    }
    
}
