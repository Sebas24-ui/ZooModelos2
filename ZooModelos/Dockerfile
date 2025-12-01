# Fase 1: Base
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080 

# Fase 2: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# -------------------- INICIO CORRECCIÓN DE SECUENCIA --------------------
# 1. Copiamos TODOS los archivos de TODAS las carpetas (Model y ZooModelos2)
COPY . .

# 2. Movemos el directorio de trabajo al proyecto principal (ZooModelos2)
WORKDIR "/src/ZooModelos2" 

# 3. Restaura y construye el proyecto principal (Ahora encuentra el .csproj)
RUN dotnet restore "ZooModelos2.csproj"
RUN dotnet build "ZooModelos2.csproj" -c Release -o /app/build
# -------------------- FIN CORRECCIÓN DE SECUENCIA ----------------------

# Fase 3: Publish
FROM build AS publish
RUN dotnet publish "ZooModelos2.csproj" -c Release -o /app/publish /p:UseAppHost=false
 
# Fase 4: Final
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ZooModelos2.dll"]