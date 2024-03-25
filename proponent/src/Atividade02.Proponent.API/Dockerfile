#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["proponent/src/Atividade02.Proponent.API/Atividade02.Proponent.API.csproj", "proponent/src/Atividade02.Proponent.API/"]
COPY ["BuildingBlocks/Atividade02.Core/Atividade02.Core.csproj", "BuildingBlocks/Atividade02.Core/"]
COPY ["BuildingBlocks/Atividade02.Core.MessageBus/Atividade02.Core.MessageBus.csproj", "BuildingBlocks/Atividade02.Core.MessageBus/"]
RUN dotnet restore "proponent/src/Atividade02.Proponent.API/Atividade02.Proponent.API.csproj"
COPY . .
WORKDIR "/src/proponent/src/Atividade02.Proponent.API"
RUN dotnet build "Atividade02.Proponent.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Atividade02.Proponent.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Atividade02.Proponent.API.dll"]
