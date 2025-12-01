FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# -------------------- CORRECCIÓN FINAL DE COPIA Y RESTAURACIÓN --------------------

# 1. Copia solo los archivos .csproj de ambos proyectos para la restauración
COPY ZooModelos2/ZooModelos2.csproj ZooModelos2/
COPY Model/Model.csproj Model/

# 2. Restaura AMBOS proyectos
# (dotnet restore ahora puede ver ambos archivos .csproj)
RUN dotnet restore ZooModelos2/ZooModelos2.csproj

# 3. Copia el resto del código
# Copia todo el contenido de la raíz del repositorio (incluyendo el código fuente de Model)
COPY . . 

# 4. Mueve el directorio de trabajo a la API
WORKDIR "/src/ZooModelos2" 

# 5. Construye el proyecto API 
RUN dotnet build "ZooModelos2.csproj" -c Release -o /app/build