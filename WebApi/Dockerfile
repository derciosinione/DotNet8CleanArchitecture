FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["R2Y_2024_API/R2Y_2024_API.csproj", "R2Y_2024_API/"]
RUN dotnet restore "./R2Y_2024_API/R2Y_2024_API.csproj"
COPY . .
WORKDIR "/src/R2Y_2024_API"
RUN dotnet build "./R2Y_2024_API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./R2Y_2024_API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY R2Y_2024_API/https/aspnetapp.pfx /https/aspnetapp.pfx
ENTRYPOINT ["dotnet", "R2Y_2024_API.dll"]
