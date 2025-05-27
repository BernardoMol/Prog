# Etapa 1: build usando .NET 9.0-preview (se quiser usar 9.0 preview)
FROM mcr.microsoft.com/dotnet/sdk:9.0-preview AS build
WORKDIR /src

# Copia os csproj para restaurar dependências
COPY Reclamao/Reclamao.csproj ./Reclamao/
COPY Api_Reclamao/Api_Reclamao.csproj ./Api_Reclamao/

RUN dotnet restore ./Api_Reclamao/Api_Reclamao.csproj

# Copia o restante do código, exceto os arquivos appsettings.json da pasta Reclamao
COPY Reclamao/ ./Reclamao/
RUN rm -f Reclamao/appsettings.json Reclamao/appsettings.Development.json

COPY Api_Reclamao/. ./Api_Reclamao/

WORKDIR /src/Api_Reclamao
RUN dotnet publish -c Release -o /app/publish

# Etapa 2: runtime
FROM mcr.microsoft.com/dotnet/aspnet:9.0-preview AS runtime
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "Api_Reclamao.dll"]
