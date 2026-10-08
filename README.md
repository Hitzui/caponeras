# Caponeras.App

Aplicación de escritorio Windows Forms para la gestión de Caponeras, con proyectos de datos e infraestructura.

## Requisitos

- Windows y .NET SDK 10.
- Acceso a los paquetes DevExpress usados por la solución.
- MySQL compatible con el modelo de datos existente.

## Configuración local

Las credenciales de base de datos no se versionan. Antes de ejecutar la aplicación:

1. Copie `Caponeras.App/appsettings.example.json` como `Caponeras.App/appsettings.json` y complete los valores de conexión.
2. Copie `Caponeras.App/App.example.config` como `Caponeras.App/App.config` y complete `reportesConnection` para los reportes.

La configuración real queda ignorada por Git. Mantenga las credenciales fuera del repositorio.

## Compilar

```powershell
dotnet restore Caponeras.App.slnx
dotnet build Caponeras.App.slnx
```
