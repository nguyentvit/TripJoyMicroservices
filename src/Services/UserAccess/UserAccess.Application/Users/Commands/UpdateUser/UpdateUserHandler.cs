namespace UserAccess.Application.Users.Commands.UpdateUser
{
    public class UpdateUserHandler
        (IApplicationDbContext dbContext)
        : ICommandHandler<UpdateUserCommand, UpdateUserResult>
    {
        public async Task<UpdateUserResult> Handle(UpdateUserCommand command, CancellationToken cancellationToken)
        {
            var userId = UserId.Of(command.User.UserId);
            var user = await dbContext.Users.FindAsync([userId], cancellationToken);

            if (user == null)
            {
                throw new UserNotFoundException(command.User.UserId);
            }

            UpdateUserWithNewValues(user, command.User);

            dbContext.Users.Update(user);
            await dbContext.SaveChangesAsync(cancellationToken);

            return new UpdateUserResult(true);
        }
        private void UpdateUserWithNewValues(User user, UserUpdateDto userUpdateDto)
        {
            var updatedUserName = UserName.Of(userUpdateDto.UserName);

            PhoneNumber phoneNumber = null!;
            Date updatedDateOfBirth = null!;
            Address updatedAddress = null!;
            FileImg updatedAvatar = null!;
            UserGender? updatedGender = null!;

            if (userUpdateDto.PhoneNumber != null)
            {
                phoneNumber = PhoneNumber.Of(
                userUpdateDto.PhoneNumber
                );
            }

            if (userUpdateDto.Address != null)
            {
                updatedAddress = Address.Of(
                    userUpdateDto.Address.District,
                    userUpdateDto.Address.Ward,
                    userUpdateDto.Address.Province,
                    userUpdateDto.Address.Country
                );
            }

            if (userUpdateDto.DateOfBirth != null)
            {
                updatedDateOfBirth = Date.Of(userUpdateDto.DateOfBirth);
            }

            if (userUpdateDto.Avatar != null)
            {
                updatedAvatar = FileImg.Of(userUpdateDto.Avatar);
            }

            if (userUpdateDto.Gender != null)
            {
                updatedGender = userUpdateDto.Gender;
            }

            user.Update(
                userName: updatedUserName,
                phone: phoneNumber,
                dateOfBirth: updatedDateOfBirth,
                avatar: updatedAvatar,
                address: updatedAddress,
                gender: updatedGender
                );
        }
    }
}
