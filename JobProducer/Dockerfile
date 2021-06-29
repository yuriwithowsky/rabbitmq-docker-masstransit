FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["JobProducer/JobProducer.csproj", "JobProducer/"]
RUN dotnet restore "JobProducer/JobProducer.csproj"
COPY . .
WORKDIR "/src/JobProducer"
RUN dotnet build "JobProducer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "JobProducer.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "JobProducer.dll"]
