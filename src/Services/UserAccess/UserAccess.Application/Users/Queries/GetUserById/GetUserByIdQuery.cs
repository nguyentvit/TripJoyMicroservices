namespace UserAccess.Application.Users.Queries.GetUserById
{
    public record GetUserByIdQuery(Guid UserId) : IQuery<GetUserByIdResult>;
    public record GetUserByIdResult(UserResponseDto User);
}
