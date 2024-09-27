namespace Authentication.API.Exceptions
{
    public class InvalidCredentialsAuthenticationException : AuthenticationException
    {
        public InvalidCredentialsAuthenticationException() : base("Authentication failed. Invalid credentials.")
        {
        }
    }
}
