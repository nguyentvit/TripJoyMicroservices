#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8180
EXPOSE 8181

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Services/ProvinceVietNam/ProvinceVietNam.API/ProvinceVietNam.API.csproj", "Services/ProvinceVietNam/ProvinceVietNam.API/"]
COPY ["BuildingBlocks/BuildingBlocks/BuildingBlocks.csproj", "BuildingBlocks/BuildingBlocks/"]
RUN dotnet restore "./Services/ProvinceVietNam/ProvinceVietNam.API/ProvinceVietNam.API.csproj"
COPY . .
WORKDIR "/src/Services/ProvinceVietNam/ProvinceVietNam.API"
RUN dotnet build "./ProvinceVietNam.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./ProvinceVietNam.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ProvinceVietNam.API.dll"]