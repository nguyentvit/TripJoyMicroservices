#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Services/PostManagement/PostManagement.API/PostManagement.API.csproj", "Services/PostManagement/PostManagement.API/"]
COPY ["BuildingBlocks/BuildingBlocks/BuildingBlocks.csproj", "BuildingBlocks/BuildingBlocks/"]
COPY ["Services/PostManagement/PostManagement.Application/PostManagement.Application.csproj", "Services/PostManagement/PostManagement.Application/"]
COPY ["BuildingBlocks/BuildingBlocks.Messaging/BuildingBlocks.Messaging.csproj", "BuildingBlocks/BuildingBlocks.Messaging/"]
COPY ["Services/PostManagement/PostManagement.Domain/PostManagement.Domain.csproj", "Services/PostManagement/PostManagement.Domain/"]
COPY ["Services/PostManagement/PostManagement.Infrastructure/PostManagement.Infrastructure.csproj", "Services/PostManagement/PostManagement.Infrastructure/"]
RUN dotnet restore "./Services/PostManagement/PostManagement.API/PostManagement.API.csproj"
COPY . .
WORKDIR "/src/Services/PostManagement/PostManagement.API"
RUN dotnet build "./PostManagement.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./PostManagement.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PostManagement.API.dll"]