FROM mcr.microsoft.com/dotnet/sdk:9.0-preview AS build
WORKDIR /src

COPY . .

RUN dotnet restore ./Api_Reclamao/Api_Reclamao.csproj

RUN rm -f ./Reclamao/appsettings.json ./Reclamao/appsettings.Development.json

WORKDIR /src/Api_Reclamao
RUN dotnet publish -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:9.0-preview AS runtime
WORKDIR /app
COPY --from=build /app/publish .
ENV ASPNETCORE_URLS=http://+:8080
ENTRYPOINT ["dotnet", "Api_Reclamao.dll"]