FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY ["frontend-api/PlaywrightWebDemo.FrontendApi.csproj", "frontend-api/"]
COPY ["shared/PlaywrightWebDemo.Shared.csproj", "shared/"]
RUN dotnet restore "frontend-api/PlaywrightWebDemo.FrontendApi.csproj"
COPY . .
WORKDIR "/src/frontend-api"
RUN dotnet build -c Release -o /app/build
RUN dotnet publish -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:10.0
WORKDIR /app
COPY --from=build /app/publish .
EXPOSE 5001
ENTRYPOINT ["dotnet", "PlaywrightWebDemo.FrontendApi.dll"]
