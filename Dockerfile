FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY . .
RUN dotnet restore "TiendaVirtual.BackEnd/TiendaVirtual.WebApi.csproj"
RUN dotnet build "TiendaVirtual.BackEnd/TiendaVirtual.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TiendaVirtual.BackEnd/TiendaVirtual.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TiendaVirtual.WebApi.dll"]