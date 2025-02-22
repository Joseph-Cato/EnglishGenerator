FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/EnglishGenerator.Presentation/EnglishGenerator.Presentation.csproj", "src/EnglishGenerator.Presentation/"]
COPY ["src/EnglishGenerator.Core/EnglishGenerator.Core.csproj", "src/EnglishGenerator.Core/"]
RUN dotnet restore "src/EnglishGenerator.Presentation/EnglishGenerator.Presentation.csproj"
COPY . .
WORKDIR "/src/src/EnglishGenerator.Presentation"
RUN dotnet build "EnglishGenerator.Presentation.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "EnglishGenerator.Presentation.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EnglishGenerator.Presentation.dll"]
