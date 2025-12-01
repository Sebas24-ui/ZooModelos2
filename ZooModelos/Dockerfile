FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# -------------------- CORRECCIÓN CRÍTICA DE COPIA DE ARCHIVOS --------------------
# 1. Copia el archivo de la LIBRERÍA DE CLASES (Model)
COPY ["Model/Model.csproj", "Model/"] 

# 2. Copia el archivo de la API (ZooModelos2)
COPY ["ZooModelos2/ZooModelos2.csproj", "ZooModelos2/"]

# 3. Restaura AMBOS proyectos.
# El compilador necesita las dos referencias para que la restauración sea exitosa.
RUN dotnet restore "ZooModelos2/ZooModelos2.csproj"

# 4. Copia el resto de los archivos (Controladores, etc.)
COPY . . 
# -------------------- FIN CORRECCIÓN CRÍTICA ------------------------------------

WORKDIR "/src/ZooModelos2" 
 
# 5. Construye el proyecto API
RUN dotnet build "ZooModelos2.csproj" -c Release -o /app/build