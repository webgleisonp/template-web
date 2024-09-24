# Etapa 1: Build da aplicação
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-stage
WORKDIR /app

# Copiar o arquivo de solução
COPY Template.Web.API.sln ./

# Copiar os projetos
COPY src/Template.Web.API/Template.Web.API.csproj ./src/Template.Web.API/
COPY src/Template.Web.API.Application/Template.Web.API.Application.csproj ./src/Template.Web.API.Application/
COPY src/Template.Web.API.Domain/Template.Web.API.Domain.csproj ./src/Template.Web.API.Domain/
COPY src/Template.Web.API.Infra.Data/Template.Web.API.Infra.Data.csproj ./src/Template.Web.API.Infra.Data/
COPY src/Template.Web.API.Presentation/Template.Web.API.Presentation.csproj ./src/Template.Web.API.Presentation/

RUN ls -R /app

# Restaurar as dependências
RUN dotnet restore

# Copiar o restante do código do diretório src
COPY src/ ./

# Definir o diretório de trabalho da API e fazer o build
WORKDIR /app/Template.Web.API
RUN dotnet publish -c Release -o /publish

# Etapa 2: Criar o ambiente de runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime-stage
WORKDIR /publish

# Copiar os artefatos de build da etapa anterior
COPY --from=build-stage /publish .

# Expor a porta 80 para que a API possa ser acessada externamente
EXPOSE 80

# Definir o ponto de entrada para rodar a API
ENTRYPOINT ["dotnet", "Template.Web.API.dll"]
