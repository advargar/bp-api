# 📘 Proyecto API RESTful - Gestión de Pólizas

Este proyecto es una API desarrollada con **ASP.NET Core Web API** usando **Entity Framework Core** y conectada a una base de datos **SQL Server (localhost)**. La API permite la gestión de clientes, pólizas y filtros avanzados para su búsqueda.

---

## 🛠️ Tecnologías Utilizadas

- ASP.NET Core Web API 7.0
- Entity Framework Core
- SQL Server (LocalDB o Express)
- Swagger (para documentación y pruebas de endpoints)
- Visual Studio 2022 o superior

---

## 🚀 Instrucciones para Ejecutar el Proyecto

### 🔧 Requisitos Previos

- Visual Studio 2022 o superior
- .NET 7 SDK o superior
- SQL Server instalado (Express o LocalDB)

---

### 1️⃣ Abre el Proyecto en Visual Studio

1. Clona o descomprime el repositorio.
2. Abre Visual Studio.
3. Abre el archivo `.sln`.

---

### 2️⃣ Configura la Conexión a la Base de Datos

Abre el archivo `appsettings.json` y asegúrate de tener una cadena de conexión válida para tu entorno:

```json
"ConnectionStrings": {
  "Conexion": "Server=(localdb)\\MSSQLLocalDB;Database=BPProyectoDb;Trusted_Connection=True;MultipleActiveResultSets=true"
}

SQL Prueba almacenada
USE [MantenimientoPoliza]
GO
/****** Object:  StoredProcedure [dbo].[sp_SearchPoliciesWithClient]    Script Date: 15 abr 2025 12:11:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Luego ejecuta el script del procedimiento
ALTER   PROCEDURE [dbo].[sp_SearchPoliciesWithClient]
    @PolicyNumber NVARCHAR(50) = NULL,
    @PolicyType NVARCHAR(50) = NULL,
    @ExpirationDate DATE = NULL,
    @InsureId NVARCHAR(50) = NULL,
    @Name NVARCHAR(100) = NULL,
    @FirstSurname NVARCHAR(100) = NULL,
    @SecondSurname NVARCHAR(100) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        p.PolicyNumber,
        p.PolicyType,
        p.ExpirationDate,
        p.ClientId as InsureId,
        c.Name,
        c.FirstSurname,
        c.SecondSurname,
        c.PersonType,
        c.Birthdate
    FROM 
        Policy p
    INNER JOIN 
        Client c ON InsureId = c.InsureId
    WHERE 
        (@PolicyNumber IS NULL OR p.PolicyNumber LIKE '%' + @PolicyNumber + '%')
        AND (@PolicyType IS NULL OR p.PolicyType LIKE '%' + @PolicyType + '%')
        AND (@ExpirationDate IS NULL OR p.ExpirationDate = @ExpirationDate)
        AND (@InsureId IS NULL OR c.InsureId LIKE '%' + @InsureId + '%')
        AND (@Name IS NULL OR c.Name LIKE '%' + @Name + '%')
        AND (@FirstSurname IS NULL OR c.FirstSurname LIKE '%' + @FirstSurname + '%')
        AND (@SecondSurname IS NULL OR c.SecondSurname LIKE '%' + @SecondSurname + '%')
END;
