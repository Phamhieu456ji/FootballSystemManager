FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

WORKDIR /src
COPY ["src/FastConnectFootballSystem.Web.Host/FastConnectFootballSystem.Web.Host.csproj", "src/FastConnectFootballSystem.Web.Host/"]
COPY ["src/FastConnectFootballSystem.Web.Core/FastConnectFootballSystem.Web.Core.csproj", "src/FastConnectFootballSystem.Web.Core/"]
COPY ["src/FastConnectFootballSystem.Application/FastConnectFootballSystem.Application.csproj", "src/FastConnectFootballSystem.Application/"]
COPY ["src/FastConnectFootballSystem.Core/FastConnectFootballSystem.Core.csproj", "src/FastConnectFootballSystem.Core/"]
COPY ["src/FastConnectFootballSystem.EntityFrameworkCore/FastConnectFootballSystem.EntityFrameworkCore.csproj", "src/FastConnectFootballSystem.EntityFrameworkCore/"]
WORKDIR "/src/src/FastConnectFootballSystem.Web.Host"
RUN dotnet restore 

WORKDIR /src
COPY ["src/FastConnectFootballSystem.Web.Host", "src/FastConnectFootballSystem.Web.Host"]
COPY ["src/FastConnectFootballSystem.Web.Core", "src/FastConnectFootballSystem.Web.Core"]
COPY ["src/FastConnectFootballSystem.Application", "src/FastConnectFootballSystem.Application"]
COPY ["src/FastConnectFootballSystem.Core", "src/FastConnectFootballSystem.Core"]
COPY ["src/FastConnectFootballSystem.EntityFrameworkCore", "src/FastConnectFootballSystem.EntityFrameworkCore"]
WORKDIR "/src/src/FastConnectFootballSystem.Web.Host"
RUN dotnet publish -c Release -o /publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:7.0
EXPOSE 80
WORKDIR /app
COPY --from=build /publish .
ENTRYPOINT ["dotnet", "FastConnectFootballSystem.Web.Host.dll"]
