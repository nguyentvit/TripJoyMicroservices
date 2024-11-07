namespace UserAccess.Application.Users.Queries.GetUserById
{
    public class GetUserByIdHandler
        (IUserRepository repository)
        : IQueryHandler<GetUserByIdQuery, GetUserByIdResult>
    {
        public async Task<GetUserByIdResult> Handle(GetUserByIdQuery query, CancellationToken cancellationToken)
        {
            var userId = UserId.Of(query.UserId);

            var user = await repository.GetUserById(userId, cancellationToken: cancellationToken);

            if (user == null)
            {
                throw new UserNotFoundException(userId.Value);
            }

            var userResponseDto = user.ToUserProfileDto();

            return new GetUserByIdResult(userResponseDto);
        }
    }
}
