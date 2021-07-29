#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["PortfolioApp.Site/PortfolioApp.Site.csproj", "PortfolioApp.Site/"]
RUN dotnet restore "PortfolioApp.Site/PortfolioApp.Site.csproj"
COPY . .
WORKDIR "/src/PortfolioApp.Site"
RUN dotnet build "PortfolioApp.Site.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PortfolioApp.Site.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PortfolioApp.Site.dll"]