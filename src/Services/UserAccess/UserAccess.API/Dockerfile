#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Services/UserAccess/UserAccess.API/UserAccess.API.csproj", "Services/UserAccess/UserAccess.API/"]
COPY ["Services/UserAccess/UserAccess.Application/UserAccess.Application.csproj", "Services/UserAccess/UserAccess.Application/"]
COPY ["BuildingBlocks/BuildingBlocks/BuildingBlocks.csproj", "BuildingBlocks/BuildingBlocks/"]
COPY ["Services/UserAccess/UserAccess.Domain/UserAccess.Domain.csproj", "Services/UserAccess/UserAccess.Domain/"]
COPY ["Services/UserAccess/UserAccess.Infrastructure/UserAccess.Infrastructure.csproj", "Services/UserAccess/UserAccess.Infrastructure/"]
RUN dotnet restore "./Services/UserAccess/UserAccess.API/UserAccess.API.csproj"
COPY . .
WORKDIR "/src/Services/UserAccess/UserAccess.API"
RUN dotnet build "./UserAccess.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./UserAccess.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "UserAccess.API.dll"]