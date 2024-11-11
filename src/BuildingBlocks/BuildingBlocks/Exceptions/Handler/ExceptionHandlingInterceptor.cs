using Grpc.Core;
using Grpc.Core.Interceptors;

namespace BuildingBlocks.Exceptions.Handler
{
    public class ExceptionHandlingInterceptor : Interceptor
    {
        public override async Task<TResponse> UnaryServerHandler<TRequest, TResponse>(
            TRequest request,
            ServerCallContext context,
            UnaryServerMethod<TRequest, TResponse> continuation)
        {
            try
            {
                return await continuation(request, context);
            }
            catch (Exception ex)
            {
                throw HandleException(ex);
            }
        }

        private RpcException HandleException(Exception exception)
        {
            return exception switch
            {
                InternalServerException =>
                    new RpcException(new Status(StatusCode.Internal, exception.Message), CreateMetadata(exception)),

                BadRequestException =>
                    new RpcException(new Status(StatusCode.InvalidArgument, exception.Message), CreateMetadata(exception)),

                NotFoundException =>
                    new RpcException(new Status(StatusCode.NotFound, exception.Message), CreateMetadata(exception)),

                AuthenticationException =>
                    new RpcException(new Status(StatusCode.Unauthenticated, exception.Message), CreateMetadata(exception)),

                _ =>
                    new RpcException(new Status(StatusCode.Unknown, "An unexpected error occurred"), CreateMetadata(exception))
            };
        }

        private Metadata CreateMetadata(Exception exception)
        {
            return new Metadata
            {
                { "ExceptionType", exception.GetType().Name },
                { "Message", exception.Message }
            };
        }
    }
}
