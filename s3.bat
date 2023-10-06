@echo off
SETLOCAL EnableDelayedExpansion

REM Establece la ruta de tu proyecto
set "DIR_PROYECTO=C:\Users\Angel Ortega\Documents\E-2"
cd /d "%DIR_PROYECTO"

REM Obtiene el nombre de la carpeta actual
for %%I in ("%DIR_PROYECTO%") do set "nombreCarpeta=%%~nxI"

REM Inicializa una variable para el arreglo vacío
set "misProyectos="

echo Nota de Recomendacion:
echo - El nombre del proyecto no debe contener símbolos.
echo - Evita usar espacios en blanco.
echo - No incluir números.
echo.
pause

:menu
cls
echo ==============================
echo       MENU DE OPCIONES
echo ==============================
echo.
echo 1. Creación del proyecto 3 Capas
echo 2. Creación de carpetas
echo 3. Salir
echo.
SET /P choice="Seleccione una opción (1-3): "

IF "%choice%"=="1" GOTO selectName
IF "%choice%"=="2" GOTO carpetas
IF "%choice%"=="3" GOTO endScript
GOTO menu

:selectName
dotnet new sln
SET /P folderName="Introduce el nombre del proyecto WebApi: "
dotnet new webapi -o "!folderName!"
dotnet add "!folderName!\!folderName!.csproj" package Microsoft.AspNetCore.Authentication.JwtBearer --version 7.0.10
dotnet add "!folderName!\!folderName!.csproj" package Microsoft.EntityFrameworkCore --version 7.0.10
dotnet add "!folderName!\!folderName!.csproj" package Microsoft.EntityFrameworkCore.Design --version 7.0.10
dotnet add "!folderName!\!folderName!.csproj" package Microsoft.Extensions.DependencyInjection --version 7.0.0
dotnet add "!folderName!\!folderName!.csproj" package System.IdentityModel.Tokens.Jwt --version 6.32.3
dotnet add "!folderName!\!folderName!.csproj" package Serilog.AspNetCore --version 7.0.0
dotnet add "!folderName!\!folderName!.csproj" package Microsoft.AspNetCore.Mvc.Versioning --version 5.1.0
dotnet add "!folderName!\!folderName!.csproj" package AspNetCoreRateLimit --version 5.0.0
dotnet add "!folderName!\!folderName!.csproj" package AutoMapper.Extensions.Microsoft.DependencyInjection --version 12.0.1
SET core=Core
dotnet new classlib -o "!core!"
SET infra=Infrastructure
dotnet new classlib -o "!infra!"
dotnet add "!infra!\!infra!.csproj" package Pomelo.EntityFrameworkCore.MySql --version 7.0.0
dotnet add "!infra!\!infra!.csproj" package Microsoft.EntityFrameworkCore --version 7.0.10
dotnet add "!infra!\!infra!.csproj" package CsvHelper --version 30.0.1

REM Agregando proyectos a la solución
echo "%DIR_PROYECTO%"
pause
dotnet sln "%DIR_PROYECTO%\%nombreCarpeta%.sln" add "!folderName!\!folderName!.csproj"
dotnet sln "%DIR_PROYECTO%\%nombreCarpeta%.sln" add "!core!\!core!.csproj"
dotnet sln "%DIR_PROYECTO%\%nombreCarpeta%.sln" add "!infra!\!infra!.csproj"

REM Agregando referencias entre proyectos
cd /d "!folderName!"
dotnet add reference "..\!infra!\!infra!.csproj"
cd /d "..\!infra!"
dotnet add reference "..\!core!\!core!.csproj"
pause

GOTO menu

:carpetas
cls
SET "rootDir=%driveLetter%:\%projectName%"
echo ===========================================================
echo       MENU DE OPCIONES SELECCIONE EL GRUPO DE CARPETAS
echo ===========================================================
echo.
echo 1. Dtos,Services,Extensions,Helpers,Profiles (Recomendado WebApi)
echo 2. Entities,Interfaces (Recomendado Core)
echo 3. Repository,UnitOfWork,Data (Recomendado Infrastructure)
echo 4. Regresar al menú principal
echo.
SET /P choice="Seleccione una opción (1-4): "

IF "%choice%"=="1" GOTO webapi
IF "%choice%"=="2" GOTO app
IF "%choice%"=="3" GOTO infrast
GOTO menu

:webapi
SET /P folderName="Introduce el nombre del proyecto WebApi: "
cd /d "%DIR_PROYECTO%\!folderName!"
mkdir Dtos
mkdir Services
mkdir Extensions
mkdir Helpers
mkdir Profiles
GOTO carpetas

:app
SET "folderName=Core"
cd /d "%DIR_PROYECTO%\!folderName!"
mkdir Entities
mkdir Interfaces
GOTO carpetas

:infrast
SET "folderName=Infrastructure"
cd /d "%DIR_PROYECTO%\!folderName!"
mkdir Repository
mkdir UnitOfWork
mkdir Data
cd /d "%DIR_PROYECTO%\!folderName!\Data"
mkdir Configuration
GOTO carpetas

:endScript
echo Gracias por usar nuestro selector!
exit
ENDLOCAL
