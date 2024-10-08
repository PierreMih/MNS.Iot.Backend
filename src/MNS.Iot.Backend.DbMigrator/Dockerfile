﻿FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
USER $APP_UID
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/MNS.Iot.Backend.DbMigrator/MNS.Iot.Backend.DbMigrator.csproj", "src/MNS.Iot.Backend.DbMigrator/"]
COPY ["src/MNS.Iot.Backend.Application.Contracts/MNS.Iot.Backend.Application.Contracts.csproj", "src/MNS.Iot.Backend.Application.Contracts/"]
COPY ["src/MNS.Iot.Backend.Domain.Shared/MNS.Iot.Backend.Domain.Shared.csproj", "src/MNS.Iot.Backend.Domain.Shared/"]
COPY ["src/MNS.Iot.Backend.EntityFrameworkCore/MNS.Iot.Backend.EntityFrameworkCore.csproj", "src/MNS.Iot.Backend.EntityFrameworkCore/"]
COPY ["src/MNS.Iot.Backend.Domain/MNS.Iot.Backend.Domain.csproj", "src/MNS.Iot.Backend.Domain/"]
RUN dotnet restore "src/MNS.Iot.Backend.DbMigrator/MNS.Iot.Backend.DbMigrator.csproj"
COPY . .
WORKDIR "/src/src/MNS.Iot.Backend.DbMigrator"
RUN dotnet build "MNS.Iot.Backend.DbMigrator.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "MNS.Iot.Backend.DbMigrator.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MNS.Iot.Backend.DbMigrator.dll"]
