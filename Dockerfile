#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 5700
ENV ASPNETCORE_URLS=http://*:5700
ENV ASPNETCORE_ENVIRONMENT=Development

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["ContactsDeleteConsumer.Api/FIAP.TechChallenge.ContactsDeleteConsumer.Api.csproj", "ContactsDeleteConsumer.Api/"]
COPY ["ContactsDeleteConsumer.Application/FIAP.TechChallenge.ContactsDeleteConsumer.Application.csproj", "ContactsDeleteConsumer.Application/"]
COPY ["ContactsDeleteConsumer.Domain/FIAP.TechChallenge.ContactsDeleteConsumer.Domain.csproj", "ContactsDeleteConsumer.Domain/"]
COPY ["ContactsDeleteConsumer.Infrastructure/FIAP.TechChallenge.ContactsDeleteConsumer.Infrastructure.csproj", "ContactsDeleteConsumer.Infrastructure/"]
RUN dotnet restore "./ContactsDeleteConsumer.Api/FIAP.TechChallenge.ContactsDeleteConsumer.Api.csproj"
COPY . .
WORKDIR "/src/ContactsDeleteConsumer.Api"
RUN dotnet build "./FIAP.TechChallenge.ContactsDeleteConsumer.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./FIAP.TechChallenge.ContactsDeleteConsumer.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FIAP.TechChallenge.ContactsDeleteConsumer.Api.dll"]