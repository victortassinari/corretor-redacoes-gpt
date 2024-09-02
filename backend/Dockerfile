# Etapa de build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /App

# Copie tudo
COPY . ./
# Restaure as dependências
RUN dotnet restore
# Compile e publique a aplicação em release
RUN dotnet publish -c Release -o out

# Etapa de runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /App
COPY --from=build-env /App/out .

# Expor a porta configurada pela variável de ambiente
ARG BACKEND_PORT=8080
ENV ASPNETCORE_URLS=http://*:${BACKEND_PORT}
EXPOSE ${BACKEND_PORT}

ENTRYPOINT ["dotnet", "backend.dll"]