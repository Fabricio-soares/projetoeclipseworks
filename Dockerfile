# Usando a imagem de runtime do .NET Core
FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

# Copiar os arquivos do seu aplicativo
COPY bin/Release/net6.0/publish/ .

# Executar o aplicativo quando o contêiner iniciar
ENTRYPOINT ["dotnet", "NomeDoSeuApp.dll"]
