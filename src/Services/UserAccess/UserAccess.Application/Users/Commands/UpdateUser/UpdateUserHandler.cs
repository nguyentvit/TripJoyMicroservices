namespace UserAccess.Application.Users.Commands.UpdateUser
{
    public class UpdateUserHandler
        (IApplicationDbContext dbContext)
        : ICommandHandler<UpdateUserCommand, UpdateUserResult>
    {
        public async Task<UpdateUserResult> Handle(UpdateUserCommand command, CancellationToken cancellationToken)
        {
            var userId = UserId.Of(command.User.Id);
            var user = await dbContext.Users.FindAsync([userId], cancellationToken: cancellationToken);

            if (user == null)
            {
                throw new UserNotFoundException(command.User.Id);
            }

            UpdateUserWithNewValues(user, command.User);

            dbContext.Users.Update(user);
            await dbContext.SaveChangesAsync(cancellationToken);

            return new UpdateUserResult(true);
        }
        private void UpdateUserWithNewValues(User user, UserUpdateDto userUpdateDto)
        {
            var updatedUserName = UserName.Of(userUpdateDto.UserName);

            var updatedPhoneNumber = PhoneNumber.Of(
                userUpdateDto.PhoneNumber
                );

            var updatedAddress = Address.Of(
                userUpdateDto.Address.District,
                userUpdateDto.Address.Ward,
                userUpdateDto.Address.Province,
                userUpdateDto.Address.Country
                );

            var updatedDateOfBirth = Date.Of(userUpdateDto.DateOfBirth);

            var updatedAvatar = Image.Of(userUpdateDto.Avatar.Url, userUpdateDto.Avatar.Format);

            user.Update(
                userName: updatedUserName,
                phone: updatedPhoneNumber,
                dateOfBirth: updatedDateOfBirth,
                avatar: updatedAvatar,
                address: updatedAddress,
                gender: userUpdateDto.Gender
                );

        }
    }
}
