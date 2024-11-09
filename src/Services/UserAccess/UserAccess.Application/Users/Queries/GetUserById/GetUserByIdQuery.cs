namespace UserAccess.Application.Users.Queries.GetUserById
{
    public record GetUserByIdQuery(
        Guid MyId,
        Guid UserId) : IQuery<GetUserByIdResult>;
    public record GetUserByIdResult(UserResponseOtherDto User);
}
