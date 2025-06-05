# Use the official .NET 8 SDK image for ARM64
FROM mcr.microsoft.com/dotnet/sdk:8.0-jammy-arm64v8 AS build
WORKDIR /src

# Copy project files
COPY *.csproj .
RUN dotnet restore

# Copy everything else and build
COPY . .
RUN dotnet publish -c Release -o /app/publish

# Runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0-jammy-arm64v8
WORKDIR /app
COPY --from=build /app/publish .

# Expose port 8080 (Railway's default)
EXPOSE 8080
ENV ASPNETCORE_URLS=http://*:8080
ENTRYPOINT ["dotnet", "FullPetFlix.dll"]