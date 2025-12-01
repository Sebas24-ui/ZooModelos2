# Fase 1: Base
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080 

# Fase 2: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src 
# -------------------- CORRECCIÓN FINAL DE RUTA Y SECUENCIA --------------------
# 1. Copia solo los archivos de proyecto al nivel de /src
COPY ZooModelos2/ZooModelos2.csproj ZooModelos2/
# Ya que tienes la librería Model, también debes copiarla al nivel /src
COPY Model/Model.csproj Model/ 

# 2. Copia todo el contenido restante (Controladores, código de entidades, etc.)
COPY . .

# 3. Restaura y construye el proyecto principal 
# (Ahora el WORKDIR se cambia antes de construir)
WORKDIR /src/ZooModelos2 
RUN dotnet restore "ZooModelos2.csproj"
RUN dotnet build "ZooModelos2.csproj" -c Release -o /app/build
# -------------------- FIN CORRECCIÓN CRÍTICA DE RUTA ----------------------

# Fase 3: Publish
FROM build AS publish
RUN dotnet publish "ZooModelos2.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Fase 4: Final
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ZooModelos2.dll"]