﻿using BuildingBlocks.Messaging.Events.Event;
using ErrorOr;
using Identity.Application.Command.VerifyOtpEmail;
using Identity.Application.Common;
using Identity.Application.Services.Interfaces;
using Identity.Domain.Common.Errors;
using Identity.Domain.Common.Models;
using MassTransit;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Identity.Application.Command.RegisterUserWithOtp
{
    public class RegisterUserWithOtpCommandHandler : IRequestHandler<RegisterUserWithOtpCommand, ErrorOr<RegisterUserWithOtpResult>>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IOTPService _oTPService;
        private readonly ISendOtpService _sendOtpService;
        private IPublishEndpoint _publishEndpoint;
        public RegisterUserWithOtpCommandHandler(
            UserManager<ApplicationUser> userManager, 
            IUnitOfWork unitOfWork, 
            IOTPService oTPService, 
            ISendOtpService sendOtpService,
            IPublishEndpoint publishEndpoint)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _oTPService = oTPService;
            _sendOtpService = sendOtpService;
            _publishEndpoint = publishEndpoint;
        }
        public async Task<ErrorOr<RegisterUserWithOtpResult>> Handle(RegisterUserWithOtpCommand request, CancellationToken cancellationToken)
        {
            if (await _userManager.FindByEmailAsync(request.Email) is not null)
            {
                return Errors.User.DuplicateEmail;
            }


            var otpHasher = await _sendOtpService.GetCachedReponseAsync(request.Email);

            if (string.IsNullOrEmpty(otpHasher))
            {
                return Errors.Otp.OtpInvalid;
            }

            var otpVerify = System.Text.Json.JsonSerializer.Deserialize<OtpVerify>(otpHasher);

            if (!_oTPService.VerifyOTP(request.Otp, otpVerify.otpHasher))
            {
                return Errors.Otp.OtpInvalid;
            }

            ApplicationUser user = new()
            {
                Email = request.Email,
                UserName = request.Email,
                PhoneNumber = request.PhoneNumber,
                Name = request.Name,
            };

            var result = await _userManager.CreateAsync(user, request.Password);
            var count = await _unitOfWork.SaveChangesAsync();

            if (result.Succeeded)
            {
                var claims = new[]
                {
                    new Claim(ClaimTypes.Name, user.Name),
                    new Claim(ClaimTypes.Role, IdentityConfig.Customer)
                };

                await _userManager.AddToRoleAsync(user, IdentityConfig.Customer);
                await _userManager.AddClaimsAsync(user, claims);
                await _sendOtpService.Remove(request.Email);

                RegisterUserDataWithOtpResult data = new(user.Id, user.UserName, user.Email);
                RegisterUserWithOtpResult registerResult = new(true, "Registration successful", data);

                var eventMessage = new AccountCreatedEvent
                {
                    AccountId = user.Id,
                    Email = request.Email,
                    Name = request.Name,
                    PhoneNumber= request.PhoneNumber
                };

                await _publishEndpoint.Publish(eventMessage, cancellationToken);

                return registerResult;
            }

            return Errors.User.RegiterError;
        }
    }
}
