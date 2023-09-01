FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["ManagerTwo/ManagerTwo.csproj", "ManagerTwo/"]
RUN dotnet restore "ManagerTwo/ManagerTwo.csproj"
COPY . .
WORKDIR "/src/ManagerTwo"
RUN dotnet build "ManagerTwo.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ManagerTwo.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ManagerTwo.dll"]
