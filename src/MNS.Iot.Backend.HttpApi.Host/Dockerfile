FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/MNS.Iot.Backend.HttpApi.Host/MNS.Iot.Backend.HttpApi.Host.csproj", "src/MNS.Iot.Backend.HttpApi.Host/"]
COPY ["src/MNS.Iot.Backend.Application/MNS.Iot.Backend.Application.csproj", "src/MNS.Iot.Backend.Application/"]
COPY ["src/MNS.Iot.Backend.Domain/MNS.Iot.Backend.Domain.csproj", "src/MNS.Iot.Backend.Domain/"]
COPY ["src/MNS.Iot.Backend.Domain.Shared/MNS.Iot.Backend.Domain.Shared.csproj", "src/MNS.Iot.Backend.Domain.Shared/"]
COPY ["src/MNS.Iot.Backend.Application.Contracts/MNS.Iot.Backend.Application.Contracts.csproj", "src/MNS.Iot.Backend.Application.Contracts/"]
COPY ["src/MNS.Iot.Backend.EntityFrameworkCore/MNS.Iot.Backend.EntityFrameworkCore.csproj", "src/MNS.Iot.Backend.EntityFrameworkCore/"]
COPY ["src/MNS.Iot.Backend.HttpApi/MNS.Iot.Backend.HttpApi.csproj", "src/MNS.Iot.Backend.HttpApi/"]
RUN dotnet restore "src/MNS.Iot.Backend.HttpApi.Host/MNS.Iot.Backend.HttpApi.Host.csproj"
COPY . .
WORKDIR "/src/src/MNS.Iot.Backend.HttpApi.Host"
RUN dotnet build "MNS.Iot.Backend.HttpApi.Host.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "MNS.Iot.Backend.HttpApi.Host.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MNS.Iot.Backend.HttpApi.Host.dll"]
