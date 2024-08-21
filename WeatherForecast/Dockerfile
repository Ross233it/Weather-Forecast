# Vedere https://aka.ms/customizecontainer per informazioni su come personalizzare il contenitore di debug e su come Visual Studio usa questo Dockerfile per compilare le immagini per un debug più rapido.

# Questa fase viene usata durante l'esecuzione da Visual Studio in modalità rapida (impostazione predefinita per la configurazione di debug)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 80


FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["WeatherForecast/WeatherForecast.csproj", "WeatherForecast/"]
COPY ["CommonClassLibrary/CommonClassLibrary.csproj", "CommonClassLibrary/"]
RUN dotnet restore "./WeatherForecast/WeatherForecast.csproj"
COPY . .
WORKDIR "/src/WeatherForecast"
RUN dotnet build "./WeatherForecast.csproj" -c $BUILD_CONFIGURATION -o /app/build


FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./WeatherForecast.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WeatherForecast.dll"]