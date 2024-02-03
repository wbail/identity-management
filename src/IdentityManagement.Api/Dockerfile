FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
ENV ASPNETCORE_URLS http://*:9999
RUN apt-get update && apt-get install curl -y

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY . .
RUN dotnet restore src/*
COPY . .
#WORKDIR "src/IdentityManagementPoc.Api/"
RUN dotnet build . -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
RUN dotnet publish . -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "IdentityManagementPoc.Api.dll"]
