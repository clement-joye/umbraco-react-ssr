#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Umbraco.React.Ssr.Web/Umbraco.React.Ssr.Web.csproj", "Umbraco.React.Ssr.Web/"]
RUN dotnet restore "Umbraco.React.Ssr.Web/Umbraco.React.Ssr.Web.csproj"
COPY ./src .
WORKDIR "/src/Umbraco.React.Ssr.Web"
RUN dotnet build "Umbraco.React.Ssr.Web.csproj" -c Debug -o /app/build
FROM build AS publish
RUN dotnet publish "Umbraco.React.Ssr.Web.csproj" -c Debug -o /app/publish

FROM base AS final
ENV DOTNET_USE_POLLING_FILE_WATCHER 1
WORKDIR /app
COPY --from=publish /app/publish .
COPY ["src/Umbraco.React.Ssr.Web/umbraco/Data/Umbraco.sqlite.db", "/app/umbraco/Data/Umbraco.sqlite.db"]
ENTRYPOINT ["dotnet", "Umbraco.React.Ssr.Web.dll"]
