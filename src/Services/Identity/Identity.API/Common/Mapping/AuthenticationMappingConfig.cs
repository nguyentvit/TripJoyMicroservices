using Identity.Application.Command.RegisterUserWithOtp;
using Identity.Application.Command.SendOtp;
using Identity.Application.Command.VerifyOtpEmail;
using Identity.Application.Common.Results;
using Identity.Contract.Authentication.Reponse;
using Identity.Contract.Authentication.Request;
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
                .Map(dest => dest.PhoneNumber, src => src.PhoneNumber)
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
        }
    }
}
