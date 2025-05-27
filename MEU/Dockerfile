FROM mcr.microsoft.com/dotnet/sdk:9.0-preview AS build
WORKDIR /src

# Copiando arquivos de projeto
COPY Api_Reclamao/Api_Reclamao.csproj Api_Reclamao/
COPY Reclamao/Reclamao.csproj Reclamao/

# Restaurando dependências
RUN dotnet restore Api_Reclamao/Api_Reclamao.csproj

# Copiando todo o código-fonte
COPY . .

# Removendo arquivos desnecessários se necessário
RUN rm -f Reclamao/appsettings.json Reclamao/appsettings.Development.json || true

# Publicando
WORKDIR /src/Api_Reclamao
RUN dotnet publish -c Release -o /app/publish

# Runtime
FROM mcr.microsoft.com/dotnet/aspnet:9.0-preview AS runtime
WORKDIR /app
COPY --from=build /app/publish .

# Define porta para Render
ENV ASPNETCORE_URLS=http://+:8080
ENTRYPOINT ["dotnet", "Api_Reclamao.dll"]
