FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["MerchandiseService.GrpcClient/MerchandiseService.GrpcClient.csproj", "MerchandiseService.GrpcClient/"]
RUN dotnet restore "MerchandiseService.GrpcClient/MerchandiseService.GrpcClient.csproj"
COPY . .
WORKDIR "/src/MerchandiseService.GrpcClient"
RUN dotnet build "MerchandiseService.GrpcClient.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MerchandiseService.GrpcClient.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MerchandiseService.GrpcClient.dll"]
