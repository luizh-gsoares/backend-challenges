FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["VUTTR/src/VUTTR.csproj", "VUTTR/src/"]
RUN dotnet restore "VUTTR/src/VUTTR.csproj"
COPY . .
WORKDIR "/src/VUTTR/src"
RUN dotnet build "VUTTR.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "VUTTR.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "VUTTR.dll"]
