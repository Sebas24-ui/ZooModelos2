# Fase 1: Base
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080 

# Fase 2: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiamos TODOS los archivos de TODAS las carpetas (Model y ZooModelos2) de una sola vez
COPY . .

# Movemos el directorio de trabajo al proyecto principal
WORKDIR "/src/ZooModelos2" 

# Restaura y construye el proyecto principal.
# Nota: Si el error persiste aquí, el .csproj DEBE ser editado para quitar la referencia.
RUN dotnet restore "ZooModelos2.csproj"
RUN dotnet build "ZooModelos2.csproj" -c Release -o /app/build

# Fase 3: Publish
FROM build AS publish
RUN dotnet publish "ZooModelos2.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Fase 4: Final
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ZooModelos2.dll"]