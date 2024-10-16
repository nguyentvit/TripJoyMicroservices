﻿using Asp.Versioning;
using Identity.Application.Command.ChangePw;
using Identity.Application.Command.Login;
using Identity.Application.Command.Logout;
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
using Microsoft.AspNetCore.Mvc;

namespace Identity.API.Controllers.v1
{
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
    }
}
