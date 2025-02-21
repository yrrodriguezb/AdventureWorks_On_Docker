# Proyecto de Restauración de Base de Datos SQL Server

Este proyecto configura un contenedor Docker con SQL Server 2022 y restaura una base de datos desde un archivo de backup.

## Estructura del Proyecto

- `Dockerfile`: Archivo de configuración para construir la imagen Docker.
- `README.md`: Este archivo de documentación.
- `restore-db.sh`: Script de bash para restaurar la base de datos desde el archivo de backup.
- `nuget.config`: Archivo de configuración de NuGet.
- `queries`: Directorio con scripts SQL replicar con LINQ.


## Herramientas Utilizadas

1. Descargar [Docker](https://www.docker.com/)
2. Descargar [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
3. [SQLCMD](https://docs.microsoft.com/en-us/sql/tools/sqlcmd-utility?view=sql-server-ver15)
4. Descargar [AdventureWorks Database](https://learn.microsoft.com/en-us/sql/samples/adventureworks-install-configure?view=sql-server-ver16&tabs=ssms) descargar el archivo OLTP AdventureWorks2022.bak, una vez descargado copiarlo en la carpeta raíz del proyecto.
5. Descargar [Net Core 6.0](https://dotnet.microsoft.com/download/dotnet/6.0)

## Instrucciones

### 1. Construir la Imagen Docker

Para construir la imagen Docker, ejecuta el siguiente comando en el directorio del proyecto:

```sh
docker build -t sqlserver-adventureworks-lt2022 .

# or

docker pull yrrodriguezb/sqlserver-adventureworks-lt2022
```

### 2. Crear el Contenedor Docker

```sh
docker run -d --name sqlserver-adventureworks -p 1400:1433 -e SA_PASSWORD="NuevaClave123*" sqlserver-adventureworks-lt2022 
```

### 3. Conectar a la Base de Datos

```sh
docker exec -it sqlserver-adventureworks /opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P 'password'
```

### 4. Peticiones HTTP

Controlador basic

```sh
# GET
# Parámetros: id
# Valores: [1 - 9]

curl -X GET https://localhost:5001/Basic?id=1
```

Contrlador Intermedio
  
```sh
# GET
# Parámetros: id
# Valores: [1 - 6]
curl -X GET https://localhost:5001/Intermediate?id=1
```