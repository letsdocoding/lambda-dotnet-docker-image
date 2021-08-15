FROM public.ecr.aws/lambda/dotnet:5.0 AS base

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim as build
WORKDIR /src
COPY ["LocationsApi.csproj", "LocationsApi/"]
RUN dotnet restore "LocationsApi/LocationsApi.csproj"

WORKDIR "/src/LocationsApi"
COPY . .
RUN dotnet build "LocationsApi.csproj" --configuration Release --output /app/build

FROM build AS publish
RUN dotnet publish "LocationsApi.csproj" \
            --configuration Release \ 
            --runtime linux-x64 \
            --self-contained false \ 
            --output /app/publish \
            -p:PublishReadyToRun=true  

FROM base AS final
WORKDIR /var/task

CMD ["LocationsApi::LocationsApi.LambdaEntryPoint::FunctionHandlerAsync"]
COPY --from=publish /app/publish .