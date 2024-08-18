# Use the official ASP.NET Core image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Use the SDK image to build the app
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["OpusClassical/OpusClassical.csproj", "OpusClassical/"]
RUN dotnet restore "OpusClassical/OpusClassical.csproj"
COPY . .
WORKDIR "/src/OpusClassical"
RUN dotnet build "OpusClassical.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "OpusClassical.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OpusClassical.dll"]