FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

# Copia apenas o .csproj e faz restore
COPY WeatherApp/WeatherApp.csproj WeatherApp/
RUN dotnet restore WeatherApp/WeatherApp.csproj

# Copia o restante da aplicação
COPY WeatherApp/ WeatherApp/

WORKDIR /src/WeatherApp
RUN dotnet build WeatherApp.csproj -c Release -o /app/build

FROM build AS publish
RUN dotnet publish WeatherApp.csproj -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WeatherApp.dll"]
