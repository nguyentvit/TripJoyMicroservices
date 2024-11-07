namespace Identity.Contract.Authentication.Response
{
    public record LoginResponse(
        string AccessToken,
        string RefreshToken,
        int ExpiresIn,
        string TokenType,
        string IdToken,
        LoginUserReponse User
        );
    public record LoginUserReponse(
        Guid? UserId,
        string UserName,
        string Email,
        string Name,
        string AccountId
        );
}
