namespace UserAccess.Application.Extensions
{
    public static class UserExtensions
    {
        public static UserDto ToUserDto(this User user)
        {
            return DtoFromUser(user);
        }
        private static UserDto DtoFromUser(User user)
        {
            return new UserDto(
                Id: user.Id.Value,
                UserName: user.UserName.Value,
                Email: user.EmailAddress.Value,
                PhoneNumber: user.Phone.Value,
                DateOfBirth: (user.DateOfBirth != null) ? user.DateOfBirth.Value.ToString() : null,
                Avatar: (user.Avatar != null) ? new ImageDto(user.Avatar.Url, user.Avatar.Format) : null,
                Address: (user.Address != null) ? new AddressDto(user.Address.District, user.Address.Ward, user.Address.Province, user.Address.Country) : null,
                Gender: (user.Gender != null) ? user.Gender : null,
                FriendIds: user.Friends.Select(f => f.FriendUserId.Value).ToList(),
                FriendRequestIds: user.FriendRequests.Select(fr => fr.UserSenderId.Value).ToList(),
                SentFriendRequestIds: user.SentFriendRequests.Select(sf => sf.UserReceiverId.Value).ToList()
                );
        }
    }
}
