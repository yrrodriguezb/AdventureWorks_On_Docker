# Usa la imagen oficial de SQL Server 2022
#FROM mcr.microsoft.com/mssql/server:2022-latest
FROM mcr.microsoft.com/mssql/server:2022-preview-ubuntu-22.04

# Establece las variables de entorno requeridas
ENV SA_PASSWORD="AYF123456*"
ENV ACCEPT_EULA="Y"
ENV MSSQL_PID="Developer"

# Crea una carpeta dentro del contenedor para almacenar el backup
RUN mkdir -p /var/opt/mssql/backup

# Cambiar al usuario root para instalar paquetes
USER root

# Instalar sqlcmd y herramientas necesarias
RUN apt-get update && apt-get install -y curl gnupg2 apt-transport-https && \
    curl -sSL https://packages.microsoft.com/keys/microsoft.asc | apt-key add - && \
    echo "deb [arch=amd64] https://packages.microsoft.com/ubuntu/22.04/prod jammy main" > /etc/apt/sources.list.d/mssql-release.list && \
    apt-get update

RUN ACCEPT_EULA=Y 

RUN apt-get install -y mssql-tools unixodbc-dev

RUN ln -s /opt/mssql-tools/bin/sqlcmd /usr/bin/sqlcmd && \
    ln -s /opt/mssql-tools/bin/bcp /usr/bin/bcp

# Copia el backup de AdventureWorks al contenedor
COPY AdventureWorks2022.bak /var/opt/mssql/backup/

# Copia el script de restauración
COPY restore-db.sh /usr/src/app/restore-db.sh

# Permisos de ejecución para el script
RUN chmod +x /usr/src/app/restore-db.sh

# Restaurar el usuario original de SQL Server
USER mssql

# Comando que se ejecutará al iniciar el contenedor
CMD ["/bin/bash", "-c", "/opt/mssql/bin/sqlservr & ./usr/src/app/restore-db.sh && wait"]