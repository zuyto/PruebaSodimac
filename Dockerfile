FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
#init Openshift
LABEL io.k8s.display-name="PRUEBA_SODIMAC" \
      io.k8s.description="Web api PRUEBA_SODIMAC" \
      io.openshift.expose-services="8080:http"

EXPOSE 8080
ENV ASPNETCORE_URLS=http://*:8080
ENV TZ=America/Bogota
#end Openshift

# Esta fase se usa para compilar el proyecto de servicio
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["PRUEBA_SODIMAC.Api/PRUEBA_SODIMAC.Api.csproj", "PRUEBA_SODIMAC.Api/"]
COPY ["PRUEBA_SODIMAC.Application/PRUEBA_SODIMAC.Application.csproj", "PRUEBA_SODIMAC.Application/"]
COPY ["PRUEBA_SODIMAC.Domain/PRUEBA_SODIMAC.Domain.csproj", "PRUEBA_SODIMAC.Domain/"]
COPY ["PRUEBA_SODIMAC.Logger/PRUEBA_SODIMAC.Logger.csproj", "PRUEBA_SODIMAC.Logger/"]
COPY ["PRUEBA_SODIMAC.Infrastructure/PRUEBA_SODIMAC.Infrastructure.csproj", "PRUEBA_SODIMAC.Infrastructure/"]
RUN dotnet restore "./PRUEBA_SODIMAC.Api/PRUEBA_SODIMAC.Api.csproj"
COPY . .
WORKDIR "/src/PRUEBA_SODIMAC.Api"
RUN dotnet build "./PRUEBA_SODIMAC.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Esta fase se usa para publicar el proyecto de servicio que se copiará en la fase final.
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./PRUEBA_SODIMAC.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Esta fase se usa en producción o cuando se ejecuta desde VS en modo normal (valor predeterminado cuando no se usa la configuración de depuración)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PRUEBA_SODIMAC.Api.dll"]
