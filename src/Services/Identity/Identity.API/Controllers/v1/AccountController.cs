using Identity.Application.Command.ChangePw;
using Identity.Application.Command.Login;
using Identity.Application.Command.LoginGoogle;
using Identity.Application.Command.Logout;
using Identity.Application.Command.RefreshToken;
using Identity.Application.Command.RegisterUserWithOtp;
using Identity.Application.Command.SendOtp;
using Identity.Application.Command.VerifyOtpEmail;
using Identity.Application.Queries.ConfirmForgetPwOtp;
using Identity.Application.Queries.ForgetPassword;
using Identity.Contract.Authentication.Reponse;
using Identity.Contract.Authentication.Request;
using Identity.Contract.Authentication.Response;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Identity.API.Controllers.v1
{
    public class AccountController : ApiController
    {
        private readonly ISender _mediator;
        private readonly IMapper _mapper;
        private IConfiguration _configuration;
        public AccountController(ISender mediator, IMapper mapper, IConfiguration configuration)
        {
            _mediator = mediator;
            _mapper = mapper;
            _configuration = configuration;
        }
        [HttpPost("send-otp-verify-email")]
        public async Task<IActionResult> SendOtpVerifyEmail([FromBody] SendOtpVerifyEmailRequest request)
        {
            var command = _mapper.Map<SendOtpCommand>(request);

            var result = await _mediator.Send(command);

            return result.Match(
                result => Ok(_mapper.Map<SendOtpResponse>(result)),
                errors => Problem(errors)
                );
        }
        [HttpPost("verify-otp-email")]
        public async Task<IActionResult> VerifyOtpEmail([FromBody] VerifyOtpEmailRequest request)
        {
            var command = _mapper.Map<VerifyOtpEmailCommand>(request);

            var result = await _mediator.Send(command);

            return result.Match(
                result => Ok(_mapper.Map<VerifyOtpEmailResponse>(result)),
                errors => Problem(errors)
                );
        }
        [HttpPost("register-with-otp")]
        public async Task<IActionResult> RegisterWithOtp([FromBody] RegisterUserWithOtpRequest request)
        {
            var command = _mapper.Map<RegisterUserWithOtpCommand>(request);

            var result = await _mediator.Send(command);

            return result.Match(
                result => Ok(_mapper.Map<RegisterUserWithOtpResponse>(result)),
                errors => Problem(errors)
                );
        }
        [HttpPost("change-password")]
        public async Task<IActionResult> ChangePw([FromQuery] string key, [FromQuery] string userId, [FromBody] ChangePwRequest request)
        {
            var command = _mapper.Map<ChangePwCommand>((key, userId, request));

            var result = await _mediator.Send(command);

            return result.Match(
                result => Ok(_mapper.Map<ChangePwResponse>(result)),
                errors => Problem(errors)
                );
        }
        [HttpPost("confirm-forget-pw")]
        public async Task<IActionResult> ConfirmForgetPwOtp([FromQuery] string key, [FromBody] ConfirmForgetPwRequest request)
        {
            var query = _mapper.Map<ConfirmForgetPwOtpQuery>((key, request));

            var result = await _mediator.Send(query);

            return result.Match(
                result => Ok(_mapper.Map<ForgetPasswordResponse>(result)),
                errors => Problem(errors)
                );
        }
        [HttpPost("forget-password")]
        public async Task<IActionResult> ForgetPassword([FromBody] ForgetPasswordRequest request)
        {
            var query = _mapper.Map<ForgetPasswordQuery>(request);

            var result = await _mediator.Send(query);

            return result.Match(
                result => Ok(_mapper.Map<ForgetPasswordResponse>(result)),
                errors => Problem(errors)
                );
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var command = _mapper.Map<LoginCommand>(request);

            var result = await _mediator.Send(command);

            return result.Match(
                result => Ok(_mapper.Map<LoginResponse>(result)),
                errors => Problem(errors)
                );
        }
        [HttpPost("logout")]
        public async Task<IActionResult> Logout([FromBody] LogoutRequest request)
        {
            var command = _mapper.Map<LogoutCommand>(request);

            var result = await _mediator.Send(command);

            return result.Match(
                result => Ok(_mapper.Map<LogoutResponse>(result)),
                errors => Problem(errors)
                );
        }
        [HttpPost("refresh")]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenRequest request)
        {
            var command = _mapper.Map<RefreshTokenCommand>(request);

            var result = await _mediator.Send(command);

            return result.Match(
                result => Ok(_mapper.Map<RefreshTokenReponse>(result)),
                errors => Problem(errors)
                );
        }
        [HttpGet("login-google")]
        public IActionResult Login()
        {
            var url = "";
            var environment = _configuration["ASPNETCORE_ENVIRONMENT"];
            if (environment == "Development")
            {
                url = "http://localhost:5032/";
            }

            else if (environment == "Production")
            {
                var port = Environment.GetEnvironmentVariable("PORT") ?? "80";
                url = $"http://identity.api:{port}/";
            }

            var clientId = "54512677689-2fi560s0sleddn285cmaaa7vjr6fcrhl.apps.googleusercontent.com";
            var redirectUri = $"{url}signin-google";
            var urlgg = $"https://accounts.google.com/o/oauth2/auth" +
                      $"?response_type=code" +
                      $"&client_id={clientId}" +
                      $"&redirect_uri={Uri.EscapeDataString(redirectUri)}" +
                      $"&scope=openid%20profile%20email" +
                      $"&access_type=offline";

            return Redirect(urlgg);
        }
        [HttpGet("signin-google")]
        public async Task<IActionResult> Callback()
        {
            var authorizationCode = HttpContext.Request.Query["code"].ToString();

            if (string.IsNullOrEmpty(authorizationCode))
            {
                return BadRequest("Authorization code is missing.");
            }

            LoginGoogleCommand command = new(authorizationCode);

            var result = await _mediator.Send(command);

            return result.Match(
                result => Ok(_mapper.Map<LoginResponse>(result)),
                errors => Problem(errors)
                );

        }
    }
}
