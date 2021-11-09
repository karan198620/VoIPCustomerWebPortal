#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:3.1 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["test/VoipProjectEntities.API.IntegrationTests/VoipProjectEntities.API.IntegrationTests.csproj", "test/VoipProjectEntities.API.IntegrationTests/"]
COPY ["src/Infrastructure/VoipProjectEntities.Persistence/VoipProjectEntities.Persistence.csproj", "src/Infrastructure/VoipProjectEntities.Persistence/"]
COPY ["src/Core/VoipProjectEntities.Application/VoipProjectEntities.Application.csproj", "src/Core/VoipProjectEntities.Application/"]
COPY ["src/Core/VoipProjectEntities.Domain/VoipProjectEntities.Domain.csproj", "src/Core/VoipProjectEntities.Domain/"]
COPY ["src/API/VoipProjectEntities.Api/VoipProjectEntities.Api.csproj", "src/API/VoipProjectEntities.Api/"]
COPY ["src/Infrastructure/VoipProjectEntities.Infrastructure/VoipProjectEntities.Infrastructure.csproj", "src/Infrastructure/VoipProjectEntities.Infrastructure/"]
COPY ["src/Infrastructure/VoipProjectEntities.Identity/VoipProjectEntities.Identity.csproj", "src/Infrastructure/VoipProjectEntities.Identity/"]
RUN dotnet restore "test/VoipProjectEntities.API.IntegrationTests/VoipProjectEntities.API.IntegrationTests.csproj"
COPY . .
WORKDIR "/src/test/VoipProjectEntities.API.IntegrationTests"
RUN dotnet build "VoipProjectEntities.API.IntegrationTests.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "VoipProjectEntities.API.IntegrationTests.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "VoipProjectEntities.API.IntegrationTests.dll"]
