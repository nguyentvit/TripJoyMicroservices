namespace Chat.Application.ExternalService
{
    public interface IUserAccessService
    {
        Task<List<UserInfoExternalServiceDto>> GetUsersInfoAsync(List<Guid> UserIds, CancellationToken cancellationToken = default);
    }
}
