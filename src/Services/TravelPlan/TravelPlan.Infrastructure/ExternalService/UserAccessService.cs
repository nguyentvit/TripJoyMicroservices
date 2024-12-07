using BuildingBlocks.Pagination;
using System.Net.Http.Json;

namespace TravelPlan.Infrastructure.ExternalService
{
    public record GetUsersInfoExternalServiceRequest(List<Guid> UserIds);
    public record GetUsersInfoExternalServiceResponse(List<UserInfoExternalServiceDto> UsersInfo);
    public record GetUsersBySearchExternalServiceResponse(PaginationResult<UserInfoExternalServiceDto> Users);
    public class UserAccessService : IUserAccessService
    {
        private readonly HttpClient _httpClient;
        public UserAccessService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<PaginationResult<UserInfoExternalServiceDto>> GetAllUsersAsync(PaginationRequest PaginationRequest, KeySearchUser keySearch, CancellationToken cancellationToken = default)
        {
            var pageIndex = PaginationRequest.PageIndex;
            var pageSize = PaginationRequest.PageSize;
            var keySearchName = keySearch.Name;

            var endpoint = $"/external/users/search?pageIndex={pageIndex}&pageSize={pageSize}&name={keySearchName}";

            var response = await _httpClient.GetAsync(endpoint, cancellationToken);

            response.EnsureSuccessStatusCode();

            var test = await response.Content.ReadAsStringAsync();
            var result = await response.Content.ReadFromJsonAsync<GetUsersBySearchExternalServiceResponse>();

            return result?.Users ?? throw new Exception("Failed get detail user from travel plan");
        }

        public async Task<List<UserInfoExternalServiceDto>> GetUsersInfoAsync(List<Guid> userIds, CancellationToken cancellationToken = default)
        {
            var endpoint = "/external/users";

            var payload = new GetUsersInfoExternalServiceRequest(userIds);

            var response = await _httpClient.PostAsJsonAsync(endpoint, payload, cancellationToken);

            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadFromJsonAsync<GetUsersInfoExternalServiceResponse>(cancellationToken: cancellationToken);

            return result?.UsersInfo ?? new List<UserInfoExternalServiceDto>();
        }
    }
}
