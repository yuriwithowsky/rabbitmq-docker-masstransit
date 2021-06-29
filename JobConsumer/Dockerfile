FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["JobConsumer/JobConsumer.csproj", "JobConsumer/"]
RUN dotnet restore "JobConsumer/JobConsumer.csproj"
COPY . .
WORKDIR "/src/JobConsumer"
RUN dotnet build "JobConsumer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "JobConsumer.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "JobConsumer.dll"]
