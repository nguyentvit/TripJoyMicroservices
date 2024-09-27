namespace Authentication.API.Models
{
    public record UserLogin
    (
        [JsonProperty("access_token")]
        string AccessToken,
        [JsonProperty("refresh_token")]
        string RefreshToken,
        [JsonProperty("expires_in")]
        int ExpiresIn,
        [JsonProperty("token_type")]
        string TokenType,
        [JsonProperty("id_token")]
        string IdToken,
        [JsonProperty("sub")]
        string SubId
    );
}
