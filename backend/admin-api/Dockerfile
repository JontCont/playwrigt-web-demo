FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["admin-api/PlaywrightWebDemo.AdminApi.csproj", "admin-api/"]
COPY ["shared/PlaywrightWebDemo.Shared.csproj", "shared/"]
RUN dotnet restore "admin-api/PlaywrightWebDemo.AdminApi.csproj"
COPY . .
WORKDIR "/src/admin-api"
RUN dotnet build -c Release -o /app/build
RUN dotnet publish -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish .
EXPOSE 5002
ENTRYPOINT ["dotnet", "PlaywrightWebDemo.AdminApi.dll"]
