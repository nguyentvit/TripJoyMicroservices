
using Chat.Application.ChatRooms.Queries.GetRecentConversation;

namespace Chat.API.Endpoints.ChatRooms
{
    public record GetRecentConversationResponse(PaginationResult<GetRecentConversationDto> Conversations);
    public class GetRecentConversation : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/rooms", async (ISender sender, IHttpContextAccessor httpContext,[AsParameters] PaginationRequest request) =>
            {
                var userId = httpContext.HttpContext!.GetUserIdFromJwt();

                var query = new GetRecentConversationQuery(request, userId);

                var result = await sender.Send(query);

                var response = result.Adapt<GetRecentConversationResponse>();

                return Results.Ok(response);
            });
        }
    }
}
