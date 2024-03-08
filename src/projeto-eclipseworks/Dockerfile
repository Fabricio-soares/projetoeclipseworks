#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/projeto-eclipseworks/projeto-eclipseworks.csproj", "src/projeto-eclipseworks/"]
COPY ["src/projeto_eclipseworks.Application/projeto_eclipseworks.Application.csproj", "src/projeto_eclipseworks.Application/"]
COPY ["src/projeto-eclipseworks.Dados/projeto-eclipseworks.Dados.csproj", "src/projeto-eclipseworks.Dados/"]
RUN dotnet restore "src/projeto-eclipseworks/projeto-eclipseworks.csproj"
COPY . .
WORKDIR "/src/src/projeto-eclipseworks"
RUN dotnet build "projeto-eclipseworks.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "projeto-eclipseworks.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "projeto-eclipseworks.dll"]