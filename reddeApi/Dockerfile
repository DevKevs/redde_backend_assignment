# Imagen base de .NET SDK para build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env

# Establecer directorio de trabajo
WORKDIR /app

# Copiar los archivos del proyecto
COPY . ./

# Restaurar dependencias
RUN dotnet restore

# Publicar la app en modo Release
RUN dotnet publish -c Release -o out

# Imagen base de .NET para producción
FROM mcr.microsoft.com/dotnet/aspnet:8.0

# Establecer directorio de trabajo
WORKDIR /app

# Copiar los archivos publicados desde la fase anterior
COPY --from=build-env /app/out .

# Exponer el puerto de la aplicación
EXPOSE 80

# Comando para correr la API
ENTRYPOINT ["dotnet", "reddeApi.dll"]
