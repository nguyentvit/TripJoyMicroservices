using Identity.Application.DomainEvents;
using Identity.Application.Services.Interfaces;
using Identity.Domain.Common.Errors;
using Identity.Domain.Common.Models;
using Microsoft.AspNetCore.Identity;

namespace Identity.Application.Queries.ForgetPassword
{
    public class ForgetPasswordQueryHandler : IRequestHandler<ForgetPasswordQuery, ErrorOr<ForgetPasswordResult>>
    {
        private readonly ITokenProvider _tokenProvider;
        private IPublisher _mediator;
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<ApplicationUser> _userManager;
        public ForgetPasswordQueryHandler(
            ITokenProvider tokenProvider,
            IMediator mediator,
            IUnitOfWork unitOfWork,
            UserManager<ApplicationUser> userManager
            )
        {
            _tokenProvider = tokenProvider;
            _mediator = mediator;
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }

        public async Task<ErrorOr<ForgetPasswordResult>> Handle(ForgetPasswordQuery request, CancellationToken cancellationToken)
        {

            var user = await _userManager.FindByEmailAsync(request.Email);

            if (user == null)
            {
                return Errors.User.NotFoundUser;
            }

            if (!user.EmailConfirmed)
            {
                return Errors.User.EmailUnConfirm;
            }

            await _mediator.Publish(new ForgetPasswordDomainEvent(user.Id, user.Email));
            int count = await _unitOfWork.SaveChangesAsync();

            var key = _tokenProvider.GenerateEmailConfirmationToken(user);
            var forgetUrl = $"/confirm-forget-pw/?key={key}";

            var message = "A link to reset your password has been sent to your email.";

            ForgetPasswordResult result = new ForgetPasswordResult("success", message, user.Email, forgetUrl);

            return result;
        }
    }
}
