FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/MNS.Iot.Backend.AuthServer/MNS.Iot.Backend.AuthServer.csproj", "src/MNS.Iot.Backend.AuthServer/"]
COPY ["src/MNS.Iot.Backend.EntityFrameworkCore/MNS.Iot.Backend.EntityFrameworkCore.csproj", "src/MNS.Iot.Backend.EntityFrameworkCore/"]
COPY ["src/MNS.Iot.Backend.Domain/MNS.Iot.Backend.Domain.csproj", "src/MNS.Iot.Backend.Domain/"]
COPY ["src/MNS.Iot.Backend.Domain.Shared/MNS.Iot.Backend.Domain.Shared.csproj", "src/MNS.Iot.Backend.Domain.Shared/"]
RUN dotnet restore "src/MNS.Iot.Backend.AuthServer/MNS.Iot.Backend.AuthServer.csproj"
COPY . .
WORKDIR "/src/src/MNS.Iot.Backend.AuthServer"
RUN dotnet build "MNS.Iot.Backend.AuthServer.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "MNS.Iot.Backend.AuthServer.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MNS.Iot.Backend.AuthServer.dll"]
