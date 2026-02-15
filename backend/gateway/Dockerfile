FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY ["gateway/PlaywrightWebDemo.Gateway.csproj", "gateway/"]
COPY ["shared/PlaywrightWebDemo.Shared.csproj", "shared/"]
RUN dotnet restore "gateway/PlaywrightWebDemo.Gateway.csproj"
COPY . .
WORKDIR "/src/gateway"
RUN dotnet build -c Release -o /app/build
RUN dotnet publish -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:10.0
WORKDIR /app
COPY --from=build /app/publish .
EXPOSE 5000
ENTRYPOINT ["dotnet", "PlaywrightWebDemo.Gateway.dll"]
