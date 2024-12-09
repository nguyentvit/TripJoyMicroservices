using Chat.Application.Dtos;
using Chat.Application.ExternalService;
using System.Net.Http.Json;

namespace Chat.Infrastructure.ExternalService
{
    public record GetUsersInfoExternalServiceRequest(List<Guid> UserIds);
    public record GetUsersInfoExternalServiceResponse(List<UserInfoExternalServiceDto> UsersInfo);
    public class UserAccessService : IUserAccessService
    {
        private readonly HttpClient _httpClient;
        public UserAccessService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<UserInfoExternalServiceDto>> GetUsersInfoAsync(List<Guid> UserIds, CancellationToken cancellationToken = default)
        {
            var endpoint = "/external/users";

            var payload = new GetUsersInfoExternalServiceRequest(UserIds);

            var response = await _httpClient.PostAsJsonAsync(endpoint, payload, cancellationToken);

            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadFromJsonAsync<GetUsersInfoExternalServiceResponse>(cancellationToken: cancellationToken);

            return result?.UsersInfo ?? new List<UserInfoExternalServiceDto>();
        }
    }
}
