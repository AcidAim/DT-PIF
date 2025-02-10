FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["XE908/XE908.csproj", "XE908/"]
RUN dotnet restore "XE908/XE908.csproj"
COPY . .
WORKDIR "/src/XE908"
RUN dotnet build "XE908.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "XE908.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "XE908.dll"]
