using Grpc.Core;
using LocationAttraction.Application.LocationCategories.Commands.CreateLocationCategory;
using LocationAttraction.Application.LocationCategories.Queries.GetLocationCategories;
using LocationAttraction.Application.Locations.Commands.AddImage;
using LocationAttraction.Application.Locations.Commands.CreateLocation;
using LocationAttraction.Application.Locations.Commands.RateLocation;
using LocationAttraction.Application.Locations.Commands.RemoveImage;
using LocationAttraction.Application.Locations.Commands.RemoveRating;
using LocationAttraction.Application.Locations.Queries.GetImagesByLocationId;
using LocationAttraction.Application.Locations.Queries.GetLocationByCoordinates;
using LocationAttraction.Application.Locations.Queries.GetLocationById;
using LocationAttraction.Application.Locations.Queries.GetRatingsByLocationId;
namespace LocationAttraction.Grpc.Services
{
    public class LocationAttractionService
        (ISender sender): LocationAttractionProtoService.LocationAttractionProtoServiceBase
    {
        // LocationCategory
        
        // CreateLocationCategory
        public override async Task<CreateLocationCategoryResponse> CreateLocationCategory(CreateLocationCategoryRequest request, ServerCallContext context)
        {
            var locationCategoryAddDto = request.Adapt<LocationCategoryAddDto>();

            var command = new CreateLocationCategoryCommand(locationCategoryAddDto);

            var result = await sender.Send(command);

            var response = result.Adapt<CreateLocationCategoryResponse>();

            return response;
        }

        // GetLocationCategories
        public override async Task<GetLocationCategoriesResponse> GetLocationCategories(GetLocationCategoriesRequest request, ServerCallContext context)
        {
            var query = new GetLocationCategoriesQuery();

            var result = await sender.Send(query);

            var response = new GetLocationCategoriesResponse();

            foreach (var item in result.LocationCategories)
            {
                response.LocationCategories.Add(item.Adapt<LocationCategory>());
            }

            return response;
        }

        // Location

        // CreateLocation
        public override async Task<CreateLocationResponse> CreateLocation(CreateLocationRequest request, ServerCallContext context)
        {
            var locationAddDto = request.Adapt<LocationAddDto>();

            var command = new CreateLocationCommand(locationAddDto);

            var result = await sender.Send(command);

            var response = result.Adapt<CreateLocationResponse>();

            return response;
        }

        // RateLocation
        public override async Task<RateLocationResponse> RateLocation(RateLocationRequest request, ServerCallContext context)
        {
            var locationRatingDto = request.Adapt<LocationRatingDto>();

            var command = new RateLocationCommand(locationRatingDto);

            var result = await sender.Send(command);

            var response = result.Adapt<RateLocationResponse>();

            return response;
        }

        // AddImageLocation
        public override async Task<AddImageLocationResponse> AddImageLocation(AddImageLocationRequest request, ServerCallContext context)
        {
            var locationAddImageDto = request.Adapt<LocationAddImageDto>();

            var command = new AddImageCommand(locationAddImageDto);

            var result = await sender.Send(command);

            var response = result.Adapt<AddImageLocationResponse>();

            return response;
        }
        // GetLocationByCoordinates
        public override async Task<GetLocationResponse> GetLocationByCoordinates(GetLocationByCoordinatesRequest request, ServerCallContext context)
        {
            var query = new GetLocationByCoordinatesQuery(request.Latitude, request.Longitude);

            var result = await sender.Send(query);

            var response = result.Adapt<GetLocationResponse>();

            return response;
        }

        // GetLocationById
        public override async Task<GetLocationResponse> GetLocationById(GetLocationByIdRequest request, ServerCallContext context)
        {
            var query = new GetLocationByIdQuery(request.LocationId);

            var result = await sender.Send(query);

            var response = result.Adapt<GetLocationResponse>();

            return response;
        }

        // GetImagesByLocationId
        public override async Task<GetImagesByLocationIdResponse> GetImagesByLocationId(GetImagesByLocationIdRequest request, ServerCallContext context)
        {
            var query = request.Adapt<GetImagesByLocationIdQuery>();

            var result = await sender.Send(query);

            var response = result.Adapt<GetImagesByLocationIdResponse>();

            foreach (var item in result.Images)
            {
                response.Images.Add(new Image
                {
                    Url = item.Url,
                    ImageId = item.ImageId
                });
            }
            return response;
        }

        // GetRatingsByLocationId
        public override async Task<GetRatingsByLocationIdResponse> GetRatingsByLocationId(GetRatingsByLocationIdRequest request, ServerCallContext context)
        {
            var query = request.Adapt<GetRatingsByLocationIdQuery>();

            var result = await sender.Send(query);

            var response = result.Adapt<GetRatingsByLocationIdResponse>();

            foreach (var item in result.Ratings)
            {
                response.Ratings.Add(new Rating
                {
                    UserId = item.UserId,
                    Value = item.Value
                });
            }

            return response;
        }
        // RemoveImageLocation
        public override async Task<RemoveImageLocationResponse> RemoveImageLocation(RemoveImageLocationRequest request, ServerCallContext context)
        {
            var command = request.Adapt<RemoveImageCommand>();

            var result = await sender.Send(command);

            var response = result.Adapt<RemoveImageLocationResponse>();

            return response;
        }

        // RemoveRatingLocation
        public override async Task<RemoveRatingLocationResponse> RemoveRatingLocation(RemoveRatingLocationRequest request, ServerCallContext context)
        {
            var command = request.Adapt<RemoveRatingCommand>();

            var result = await sender.Send(command);

            var response = result.Adapt<RemoveRatingLocationResponse>();

            return response;
        }
    }
}
