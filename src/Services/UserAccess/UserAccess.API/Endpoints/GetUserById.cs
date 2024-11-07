﻿using UserAccess.Application.Users.Queries.GetUserById;

namespace UserAccess.API.Endpoints
{
    public record GetUserByIdResponse(UserResponseDto User);
    public class GetUserById : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/users/{userId}", async (Guid userId, ISender sender) =>
            {
                var result = await sender.Send(new GetUserByIdQuery(userId));

                var response = result.Adapt<GetUserByIdResponse>();

                return Results.Ok(response);
            })
            .WithName("GetUserById")
            .Produces<GetUserByIdResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .WithSummary("Get User By Id")
            .WithDescription("Get User By Id");
        }
    }
}
