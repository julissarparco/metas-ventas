# METAS (DESAFIO V1.0)

Proyecto para desafio tecnico que incluye FE + BE usando ASP.NET (v7.0)

## Tabla de Contenidos

- [METAS (DESAFIO V1.0)](#metas-desafio-v10)
  - [Tabla de Contenidos](#tabla-de-contenidos)
  - [Requisitos](#requisitos)
  - [Instalación](#instalación)
  - [Uso](#uso)
  - [Estructura de Carpetas](#estructura-de-carpetas)
  - [Configuración](#configuración)
  - [Ejecución](#ejecución)
  - [Contribución](#contribución)
  - [Licencia](#licencia)
  - [Contacto](#contacto)

## Requisitos

- Visual Studio (IDE)
- Microsoft SQL Server Management (DBMS)
- dotnet (CLI)

## Instalación

- Clonar el repositorio
- Abrir el proyecto en Visual Studio
- Instalar las dependencias del proyecto (NuGet)
- Abrir el archivo `appsettings.json` y modificar la cadena de conexión a la base de datos
- Abrir el archivo `log4net.config` y modificar la ruta de los archivos de log
- Abrir el archivo `appsettings.json` de `BCP.META.Presentation` y modifica la ruta de la API
- Crea la base de datos ejecutando el script `db.sql` ubicado en Misc
- Ejecutar el proyecto
  - Si se ejecuta desde Visual Studio, se abrirá una ventana del navegador con la URL de la API (F5)
  - Si se ejecuta desde la CLI, se mostrará la URL de la API en la consola
	- `dotnet run` o `dotnet watch run`

## Estructura de Carpetas

- `01. Presentacion`
  - `BCP.META.Presentation`
- `02. Distributed`
	- `BCP.Distributed`
- `03. Application`
	- `BCP.META.Application.DTO`
    - `BCP.META.Application.Service`
- `04. Domain`
	- `BCP.META.Entities`
- `05. Infrastructure`
	- `BCP.META.Infrastructure.Connections`
	- `BCP.META.Infrastructure.Repository`
	- `BCP.META.Infrastructure.UnitOfWork`
	- `BCP.META.Infrastructure.UnitOfWork.Repository`
- `06. CrossCutting`
	- `BCP.META.Crosscuting`
- `07. Framework`
	- `BCP.META.Framework.Logger`
- `11. Misc`
	- `db.sql`

## Configuración

Variables de entorno:
- `ServiceBaseUrl`: URL de la API
- `BD_BCP`: Cadena de conexión a la base de datos

## Scope

- [x] Crear un proyecto Backend (API), que permita gestionar el control de las ventas de los
asesores comerciales.
- [x] Utilizar patrones de desarrollo y aplicar buenas prácticas.
- [x] Utilizar leguaje de programación C#.
- [x] La información se debe registrar en una base de datos Sql Server.
- [x] Utilizar github o gitlab, donde se pueda apreciar el progreso del desarrollo (commits).
- [ ] Implementar un nivel de seguridad del API (token jwt).
- [x] Implementar un frontend usando Razor, MVC o Blazor, que consuma una de las API.
- [ ] Se debe de consumir una API externa en código C#
(https://jsonplaceholder.typicode.com/users) para realizar el registro de los asesores
comerciales.
- [x] Desplegar la API y front en un entorno cloud u Onpremise.

## Supuestos (Asunciones)

El objetivo es permitir el control de ventas de manera automatizada e intuitivo, para ello se debe seguir los siguientes pasos:

- Crear una nueva agencia
- Crear un nuevo Gerente de agencia
- Definir una nueva meta como Gerencia de Agencia
- Crear un nuevo Asesor Comercial
- Crear un nuevo Cliente
- Crear una nueva Venta

## Despliegue

- API: https://bcp-metas.azurewebsites.net/
- FE: https://bcp-metas-fe.azurewebsites.net/Ventas
