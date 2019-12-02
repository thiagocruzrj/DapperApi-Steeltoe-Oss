FROM mcr.microsoft.com/dotnet/core/aspnet:3.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.0 AS build
WORKDIR /src
COPY ["Dapper.Api.csproj", "./"]
RUN dotnet restore "./Dapper.Api.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "Dapper.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Dapper.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Dapper.Api.dll"]
