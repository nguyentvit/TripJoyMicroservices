namespace UserAccess.Application.Users.Commands.UpdateUser
{
    public record UpdateUserCommand(UserUpdateDto User) : ICommand<UpdateUserResult>;
    public record UpdateUserResult(bool IsSuccess);
    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator()
        {

        }
    }
}
