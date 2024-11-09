using Identity.Application.Command.ChangePw;
using Identity.Application.Command.Login;
using Identity.Application.Command.Logout;
using Identity.Application.Command.RefreshToken;
using Identity.Application.Command.RegisterUserWithOtp;
using Identity.Application.Command.SendOtp;
using Identity.Application.Command.VerifyOtpEmail;
using Identity.Application.Common.Results;
using Identity.Application.Queries.ConfirmForgetPwOtp;
using Identity.Application.Queries.ForgetPassword;
using Identity.Contract.Authentication.Reponse;
using Identity.Contract.Authentication.Request;
using Identity.Contract.Authentication.Response;
using Mapster;

namespace Identity.API.Common.Mapping
{
    public class AuthenticationMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<SendOtpVerifyEmailRequest, SendOtpCommand>()
                .Map(dest => dest.Email, src => src.Email);

            config.NewConfig<SendOtpResult, SendOtpResponse>()
                .Map(dest => dest.Email, src => src.Email)
                .Map(dest => dest.Message, src => src.Message);

            config.NewConfig<VerifyOtpEmailRequest, VerifyOtpEmailCommand>()
                .Map(dest => dest.Email, src => src.Email)
                .Map(dest => dest.Otp, src => src.Otp);

            config.NewConfig<VerifyOtpEmailResult, VerifyOtpEmailResponse>()
                .Map(dest => dest.Email, src => src.Email)
                .Map(dest => dest.Message, src => src.Message);

            config.NewConfig<RegisterUserWithOtpRequest, RegisterUserWithOtpCommand>()
                .Map(dest => dest.Email, src => src.Email)
                .Map(dest => dest.Name, src => src.Name)
                .Map(dest => dest.Password, src => src.Password)
                .Map(dest => dest.ConfirmPassword, src => src.ConfirmPassword)
                .Map(dest => dest.Otp, src => src.Otp);

            config.NewConfig<RegisterUserWithOtpResult, RegisterUserWithOtpResponse>()
                .Map(dest => dest.success, src => src.success)
                .Map(dest => dest.message, src => src.message)
                .Map(dest => dest.data, src => src.data);

            config.NewConfig<RegisterUserDataWithOtpResult, RegisterUserWithOtpDataResponse>()
                .Map(dest => dest.userId, src => src.userId)
                .Map(dest => dest.userName, src => src.userName)
                .Map(dest => dest.email, src => src.email);

            config.NewConfig<ForgetPasswordRequest, ForgetPasswordQuery>()
                .Map(dest => dest.Email, src => src.Email);

            config.NewConfig<ForgetPasswordResult, ForgetPasswordResponse>()
                .Map(dest => dest.Status, src => src.Status)
                .Map(dest => dest.Message, src => src.Message)
                .Map(dest => dest.Email, src => src.Email)
                .Map(dest => dest.Url, src => src.Url);

            config.NewConfig<(string hashedUserId, ConfirmForgetPwRequest request), ConfirmForgetPwOtpQuery>()
                .Map(dest => dest.Otp, src => src.request.Otp)
                .Map(dest => dest.HashedUserId, src => src.hashedUserId);

            config.NewConfig<(string key, string userId, ChangePwRequest request), ChangePwCommand>()
                .Map(dest => dest.ConfirmPassword, src => src.request.ConfirmPassword)
                .Map(dest => dest.Password, src => src.request.Password)
                .Map(dest => dest.Key, src => src.key)
                .Map(dest => dest.UserId, src => src.userId);

            config.NewConfig<ChangePwResult, ChangePwResponse>()
                .Map(dest => dest.Message, src => src.Message)
                .Map(dest => dest.Status, src => src.Status);

            config.NewConfig<LoginRequest, LoginCommand>()
                .Map(dest => dest.Email, src => src.Email)
                .Map(dest => dest.Password, src => src.Password);

            config.NewConfig<LoginUserResult, LoginUserReponse>()
                .Map(dest => dest.Email, src => src.Email)
                .Map(dest => dest.UserId, src => src.UserId)
                .Map(dest => dest.Name, src => src.Name)
                .Map(dest => dest.UserName, src => src.UserName)
                .Map(dest => dest.AccountId, src => src.AccountId);

            config.NewConfig<LoginResult, LoginResponse>()
                .Map(dest => dest.User, src => src.User)
                .Map(dest => dest.AccessToken, src => src.AccessToken)
                .Map(dest => dest.RefreshToken, src => src.RefreshToken)
                .Map(dest => dest.ExpiresIn, src => src.ExpiresIn)
                .Map(dest => dest.TokenType, src => src.TokenType)
                .Map(dest => dest.IdToken, src => src.IdToken);

            config.NewConfig<LogoutRequest, LogoutCommand>()
                .Map(dest => dest.RefreshToken, src => src.RefreshToken);

            config.NewConfig<LogoutResult, LogoutResponse>()
                .Map(dest => dest.Status, src => src.Status)
                .Map(dest => dest.Message, src => src.Message);

            config.NewConfig<RefreshTokenRequest, RefreshTokenCommand>()
                .Map(dest => dest.RefreshToken, src => src.RefreshToken);

            config.NewConfig<RefreshTokenResult, RefreshTokenReponse>()
                .Map(dest => dest.AccessToken, src => src.AccessToken)
                .Map(dest => dest.RefreshToken, src => src.RefreshToken)
                .Map(dest => dest.ExpiresIn, src => src.ExpiresIn)
                .Map(dest => dest.TokenType, src => src.TokenType)
                .Map(dest => dest.IdToken, src => src.IdToken);
        }
    }
}
