#!/bin/bash
# Espera a que SQL Server se inicie completamente
echo "Esperando a que SQL Server inicie..."
sleep 40s


# Conéctarse a SQL Server y restaura el backup
echo "Restaurando la base de datos AdventureWorks2022..."
/opt/mssql-tools/bin/sqlcmd -S localhost -U SA -P "AYF123456*" -Q "
RESTORE DATABASE [AdventureWorks2022]
FROM DISK = '/var/opt/mssql/backup/AdventureWorks2022.bak'
WITH
    MOVE 'AdventureWorks2022' TO '/var/opt/mssql/data/AdventureWorks2022_Data.mdf',
    MOVE 'AdventureWorks2022_log' TO '/var/opt/mssql/data/AdventureWorks2022_log.ldf',
    FILE = 1,
    NOUNLOAD,
    STATS = 5;
"
echo "Base de datos AdventureWorks2022 restaurada correctamente."