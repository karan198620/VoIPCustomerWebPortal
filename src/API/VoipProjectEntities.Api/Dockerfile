#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["src/API/VoipProjectEntities.Api/VoipProjectEntities.Api.csproj", "src/API/VoipProjectEntities.Api/"]
COPY ["src/Infrastructure/VoipProjectEntities.Infrastructure/VoipProjectEntities.Infrastructure.csproj", "src/Infrastructure/VoipProjectEntities.Infrastructure/"]
COPY ["src/Core/VoipProjectEntities.Application/VoipProjectEntities.Application.csproj", "src/Core/VoipProjectEntities.Application/"]
COPY ["src/Core/VoipProjectEntities.Domain/VoipProjectEntities.Domain.csproj", "src/Core/VoipProjectEntities.Domain/"]
COPY ["src/Infrastructure/VoipProjectEntities.Identity/VoipProjectEntities.Identity.csproj", "src/Infrastructure/VoipProjectEntities.Identity/"]
COPY ["src/Infrastructure/VoipProjectEntities.Persistence/VoipProjectEntities.Persistence.csproj", "src/Infrastructure/VoipProjectEntities.Persistence/"]
RUN dotnet restore "src/API/VoipProjectEntities.Api/VoipProjectEntities.Api.csproj"
COPY . .
WORKDIR "/src/src/API/VoipProjectEntities.Api"
RUN dotnet build "VoipProjectEntities.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "VoipProjectEntities.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "VoipProjectEntities.Api.dll"]
