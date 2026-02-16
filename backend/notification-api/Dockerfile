FROM mcr.microsoft.com/dotnet/aspnet:10.0-preview AS base
WORKDIR /app
EXPOSE 5004

FROM mcr.microsoft.com/dotnet/sdk:10.0-preview AS build
WORKDIR /src
COPY ["notification-api/PlaywrightWebDemo.NotificationApi.csproj", "notification-api/"]
COPY ["shared/PlaywrightWebDemo.Shared.csproj", "shared/"]
RUN dotnet restore "notification-api/PlaywrightWebDemo.NotificationApi.csproj"
COPY . .
WORKDIR "/src/notification-api"
RUN dotnet build "PlaywrightWebDemo.NotificationApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PlaywrightWebDemo.NotificationApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PlaywrightWebDemo.NotificationApi.dll"]
