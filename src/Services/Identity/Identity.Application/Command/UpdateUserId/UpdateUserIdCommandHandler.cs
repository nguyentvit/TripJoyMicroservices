using Identity.Application.Common.Persistence;
using Identity.Domain.Common.Models;
using Microsoft.AspNetCore.Identity;

namespace Identity.Application.Command.UpdateUserId
{
    public class UpdateUserIdCommandHandler
        : IRequestHandler<UpdateUserIdCommand, UpdateUserIdResult>
    {
        private readonly IApplicationUserQueryRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        public UpdateUserIdCommandHandler(IApplicationUserQueryRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<UpdateUserIdResult> Handle(UpdateUserIdCommand request, CancellationToken cancellationToken)
        {
            var account = _repository.GetUserByUserId(request.AccountId);

            if (account == null)
            {
                throw new Exception("not found");
            }

            account.UserId = request.UserId;
            _unitOfWork.Users.Update(account);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return new UpdateUserIdResult(true);
        }
    }
}
