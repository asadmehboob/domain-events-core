# Domain Events Modular Monolith
Modular Monolithic Architecture with .NET

## Creating docker sql server in docker desktop
docker run --platform=linux/amd64 --name MSSQL -e ACCEPT_EULA=1 -e MSSQL_SA_PASSWORD=Zxcvb@123 -p 1433:1433  -v mssql_data:/var/opt/mssql -d mcr.microsoft.com/mssql/server:2022-latest