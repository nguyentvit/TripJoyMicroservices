namespace UserAccess.Application.Users.Commands.UpdateUser
{
    public record UpdateUserCommand(UserUpdateDto User) : ICommand<UpdateUserResult>;
    public record UpdateUserResult(bool IsSuccess);
    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator()
        {
            RuleFor(u => u.User.UserId)
                .NotNull().WithMessage("Unauthorized")
                .NotEmpty().WithMessage("Unauthorized");

            RuleFor(u => u.User.UserName)
                .NotNull().WithMessage("Username cannot be null")
                .NotEmpty().WithMessage("Username cannot be empty")
                .Length(3, 50).WithMessage("Username must be between 3 and 50 characters");

            RuleFor(u => u.User.PhoneNumber)
                .NotEmpty().WithMessage("Phone number cannot be empty.")
                .Matches(@"^\d{9,11}$").WithMessage("Phone number must be between 9 and 11 digits.")
                .Length(9, 11).WithMessage("Phone number must be between 9 and 11 digits.");

            RuleFor(u => u.User.DateOfBirth)
                .Must(DateOfBirthIsValid).WithMessage("If DateOfBirth is provided, DateOfBirth must be specified");

            RuleFor(u => u.User.Gender)
                .Must(GenderIsValid).WithMessage("If Gender is provided, Gender must be specified");

            RuleFor(u => u.User.Avatar)
                .Must(AvatarIsValid).WithMessage("If Avatar is provided, both Url and Format must be specified.");

            RuleFor(u => u.User.Address)
                .Must(AddressIsValid).WithMessage("If Address is provided, Address must be specified");
        }

        private bool DateOfBirthIsValid(string? date)
        {
            if (date != null)
            {
                return DateTime.TryParse(date, out _);
            }

            return true;
        }

        private bool AvatarIsValid(ImageDto? avatar)
        {
            if (avatar != null)
            {
                return !string.IsNullOrWhiteSpace(avatar.Url) && Enum.IsDefined(typeof(ImageFormat), avatar.Format);
            }

            return true;
        }

        private bool GenderIsValid(UserGender? gender)
        {
            if (gender != null)
            {
                return Enum.IsDefined(typeof(UserGender), gender);
            }

            return true;
        }

        private bool AddressIsValid(AddressDto? address)
        {
            if (address != null)
            {
                return !string.IsNullOrWhiteSpace(address.Province) && !string.IsNullOrWhiteSpace(address.Ward) && !string.IsNullOrWhiteSpace(address.District);
            }
            return true;
        }
    }
}
