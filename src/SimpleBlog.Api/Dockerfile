#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 5001
EXPOSE 5011

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["./SimpleBlog.Api/SimpleBlog.Api.csproj", "SimpleBlog.Api/"]

RUN dotnet restore "SimpleBlog.Api/SimpleBlog.Api.csproj"
COPY . .
WORKDIR "SimpleBlog.Api"
RUN dotnet build "SimpleBlog.Api.csproj" -c Release -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "SimpleBlog.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SimpleBlog.Api.dll"]