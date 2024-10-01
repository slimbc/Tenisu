FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /src

COPY ["Tenisu/Tenisu.csproj", "Tenisu/"]
RUN dotnet restore "Tenisu/Tenisu.csproj"

COPY ["Tenisu/", "Tenisu/"]
RUN dotnet build "Tenisu/Tenisu.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Tenisu/Tenisu.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=publish /app/publish .

ENV ASPNETCORE_URLS=http://+:5001
EXPOSE 5001

ENTRYPOINT ["dotnet", "Tenisu.dll"]
