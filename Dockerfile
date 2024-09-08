FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env

WORKDIR /App
COPY . .
RUN dotnet restore
RUN dotnet publish -c Release -o out -f net8.0

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /App
COPY --from=build-env /App/out .
EXPOSE 8080
ENTRYPOINT ["dotnet"]
CMD ["shop-app.api.dll"]
