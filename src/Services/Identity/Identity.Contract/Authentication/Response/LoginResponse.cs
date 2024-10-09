﻿namespace Identity.Contract.Authentication.Response
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
        string Id,
        string UserName,
        string Email,
        string Name
        );
}
