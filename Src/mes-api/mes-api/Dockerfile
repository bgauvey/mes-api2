#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0-preview AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0-preview AS build
RUN dotnet dev-certs https
WORKDIR /src
COPY ["mes-api/mes-api.csproj", "mes-api/"]
COPY ["Service/BOL.API.Service.csproj", "Service/"]
COPY ["Domain/BOL.API.Domain.csproj", "Domain/"]
COPY ["Repository/BOL.API.Repository.csproj", "Repository/"]
RUN dotnet restore "mes-api/mes-api.csproj"
COPY . .
WORKDIR "/src/mes-api"
RUN dotnet build "mes-api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "mes-api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /root/.dotnet/corefx/cryptography/x509stores/my/* /root/.dotnet/corefx/cryptography/x509stores/my/
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "mes-api.dll"]
