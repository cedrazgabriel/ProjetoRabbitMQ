﻿FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# Definir a variável de ambiente para o ASP.NET Core
ENV ASPNETCORE_ENVIRONMENT=Development

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["ProjetoRabbitMQ/ProjetoRabbitMQ.csproj", "ProjetoRabbitMQ/"]
RUN dotnet restore "ProjetoRabbitMQ/ProjetoRabbitMQ.csproj"
COPY . .
WORKDIR "/src/ProjetoRabbitMQ"
RUN dotnet build "ProjetoRabbitMQ.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "ProjetoRabbitMQ.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ProjetoRabbitMQ.dll"]
