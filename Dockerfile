FROM mcr.microsoft.com/dotnet/sdk:8.0-alpine AS development
COPY . /app
WORKDIR /app
CMD dotnet run --launch-profile http

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /App
COPY . ./
RUN dotnet restore
RUN dotnet publish -c Release -o Dist

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /App
COPY --from=build-env /App/Dist .
ENTRYPOINT ["dotnet", "TodoApi.dll"]
