using Asp.Versioning;
using Identity.Application.Command.RegisterUserWithOtp;
using Identity.Application.Command.SendOtp;
using Identity.Application.Command.VerifyOtpEmail;
using Identity.Contract.Authentication.Reponse;
using Identity.Contract.Authentication.Request;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Identity.API.Controllers.v1
{
    [ApiVersion(1.0)]
    public class AccountController : ApiController
    {
        private readonly ISender _mediator;
        private readonly IMapper _mapper;
        public AccountController(ISender mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
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
    }
}
