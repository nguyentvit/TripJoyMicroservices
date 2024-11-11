#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Services/Location/LocationAttraction.Grpc/LocationAttraction.Grpc.csproj", "Services/Location/LocationAttraction.Grpc/"]
COPY ["BuildingBlocks/BuildingBlocks/BuildingBlocks.csproj", "BuildingBlocks/BuildingBlocks/"]
COPY ["Services/Location/LocationAttraction.Application/LocationAttraction.Application.csproj", "Services/Location/LocationAttraction.Application/"]
COPY ["Services/Location/LocationAttraction.Domain/LocationAttraction.Domain.csproj", "Services/Location/LocationAttraction.Domain/"]
COPY ["Services/Location/LocationAttraction.Infrastructure/LocationAttraction.Infrastructure.csproj", "Services/Location/LocationAttraction.Infrastructure/"]
RUN dotnet restore "./Services/Location/LocationAttraction.Grpc/LocationAttraction.Grpc.csproj"
COPY . .
WORKDIR "/src/Services/Location/LocationAttraction.Grpc"
RUN dotnet build "./LocationAttraction.Grpc.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./LocationAttraction.Grpc.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LocationAttraction.Grpc.dll"]