
FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["CouponsBot/CouponsBot.csproj", "CouponsBot/CouponsBot/"]
COPY ["CouponsBot.Domain/CouponsBot.Domain.csproj", "CouponsBot/CouponsBot.Domain/"]
COPY ["CouponsBot.Interfaces/CouponsBot.Interfaces.csproj", "CouponsBot/CouponsBot.Interfaces/"]
COPY ["CouponsBot.Persistence/CouponsBot.Persistence.csproj", "CouponsBot/CouponsBot.Persistence/"]
WORKDIR "/src/CouponsBot/"
RUN dotnet restore "CouponsBot/CouponsBot.csproj"
COPY . .
RUN dotnet build "CouponsBot/CouponsBot.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CouponsBot/CouponsBot.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CouponsBot.dll"]
