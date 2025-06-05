FROM mcr.microsoft.com/dotnet/sdk:8.0-jammy-arm64v8 AS build
# 👇 Update these lines to point to your subfolder
WORKDIR /src/FullPetFlix
COPY FullPetFlix/*.csproj .
RUN dotnet restore
COPY FullPetFlix/ .
# 👆 All paths now correctly reference the subfolder
RUN dotnet publish -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0-jammy-arm64v8
WORKDIR /app
COPY --from=build /app/publish .
EXPOSE 8080
ENV ASPNETCORE_URLS=http://*:8080
ENTRYPOINT ["dotnet", "FullPetFlix.dll"]