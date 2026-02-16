FROM mcr.microsoft.com/dotnet/aspnet:10.0-preview AS base
WORKDIR /app
EXPOSE 5003

FROM mcr.microsoft.com/dotnet/sdk:10.0-preview AS build
WORKDIR /src
COPY ["order-api/PlaywrightWebDemo.OrderApi.csproj", "order-api/"]
COPY ["shared/PlaywrightWebDemo.Shared.csproj", "shared/"]
RUN dotnet restore "order-api/PlaywrightWebDemo.OrderApi.csproj"
COPY . .
WORKDIR "/src/order-api"
RUN dotnet build "PlaywrightWebDemo.OrderApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PlaywrightWebDemo.OrderApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PlaywrightWebDemo.OrderApi.dll"]
