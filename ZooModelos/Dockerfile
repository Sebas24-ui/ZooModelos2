FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# -------------------- INICIO CORRECCIÓN DE MÚLTIPLES PROYECTOS --------------------

# 1. Copia el archivo de la LIBRERÍA DE CLASES
COPY ["Model/Model.csproj", "Model/"] 

# 2. Copia el archivo de la API
COPY ["ZooModelos2/ZooModelos2.csproj", "ZooModelos2/"]

# 3. Restaura AMBOS proyectos (dotnet restore busca las referencias automáticamente)
RUN dotnet restore "ZooModelos2/ZooModelos2.csproj"

# 4. Copia el resto de los archivos (controladores, clases, etc.)
COPY . . 

# 5. Mueve el directorio de trabajo a la API
WORKDIR "/src/ZooModelos2" 

# 6. Construye el proyecto API
RUN dotnet build "ZooModelos2.csproj" -c $BUILD_CONFIGURATION -o /app/build