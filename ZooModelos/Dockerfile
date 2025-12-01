FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# -------------------- CORRECCIÓN FINAL DE RUTAS DE COPIA --------------------
# 1. Copia el archivo de la LIBRERÍA DE CLASES
# Asumiendo que Model y ZooModelos2 están en la raíz del repositorio.
COPY Model Model/
COPY ZooModelos2 ZooModelos2/

# 2. Restaura AMBOS proyectos.
# Usamos el archivo .sln para restaurar ambos proyectos si existe, si no, restauramos la API.
# Si el archivo de la solución está en la raíz, úsalo:
# COPY ZooModelos2.sln .
# RUN dotnet restore ZooModelos2.sln

# Si no hay .sln, restauramos solo la API (que trae la referencia a Model).
RUN dotnet restore ZooModelos2/ZooModelos2.csproj

# 3. Copia el resto de los archivos (Controladores, etc.)
COPY . . 
# -------------------- FIN CORRECCIÓN CRÍTICA DE RUTAS ----------------------

WORKDIR "/src/ZooModelos2" 

# 4. Construye el proyecto API 
RUN dotnet build "ZooModelos2.csproj" -c Release -o /app/build