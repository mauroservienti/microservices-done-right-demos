#Requires -RunAsAdministrator

$instanceName = "microservices-done-right"

$serverName = "(localdb)\" + $instanceName
sqlcmd -S $serverName -i ".\Teardown-Databases.sql"

sqllocaldb stop $instanceName
sqllocaldb delete $instanceName