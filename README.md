# TiendaVirtual.BackEnd

API REST perteneciente a **Tienda Virtual**, una aplicación web de comercio electrónico
orientada a la venta de juegos de mesa y productos de ocio (videojuegos, libros,
coleccionables y puzzles). Proyecto integrado de DAW — curso 2025/2026.

## Descripción

Este repositorio contiene el backend de la aplicación, desarrollado con **ASP.NET Core 8**
siguiendo una arquitectura limpia en capas. Expone una API REST que consume el frontend
Angular y se comunica con la base de datos SQL Server mediante Entity Framework Core.

## Arquitectura

El proyecto está dividido en cuatro capas independientes:

- **TiendaVirtual.Domain** — entidades, interfaces de repositorios y servicios. Sin dependencias externas.
- **TiendaVirtual.Application** — lógica de negocio, DTOs, mapeos con AutoMapper y servicios.
- **TiendaVirtual.Infrastructure** — implementación de repositorios, DbContext y configuración de EF Core.
- **TiendaVirtual.WebApi** — controllers, configuración de JWT, Swagger y punto de entrada de la aplicación.

## Funcionalidades implementadas

- Autenticación mediante JWT (login y registro de usuarios)
- Hasheo de contraseñas con BCrypt
- Control de acceso por roles (Admin / Cliente)
- CRUD completo de productos
- Filtrado de productos por categoría
- Borrado lógico (ningún registro se elimina físicamente de la base de datos)
- Campos de auditoría en todas las entidades (usuario y fecha de creación y modificación)
- Documentación de la API con Swagger

## Tablas cubiertas actualmente

- **Role / User** — autenticación y control de acceso
- **Category / Product** — catálogo de productos
- **BoardGame** — información específica de juegos de mesa

## Requisitos

- .NET 8 SDK
- SQL Server 2022 o LocalDB
- Visual Studio 2022

## Configuración

Crea o edita el archivo `appsettings.Development.json` en el proyecto `TiendaVirtual.WebApi`
con tu cadena de conexión y los valores JWT:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=...;Database=...;Trusted_Connection=True;TrustServerCertificate=True;"
  },
  "Jwt": {
    "Key": "tu_clave_secreta",
    "Issuer": "TiendaVirtual",
    "Audience": "TiendaVirtualUsers"
  }
}
```

> Este archivo está en `.gitignore` y no se sube al repositorio.

## Ejecución

1. Abre `TiendaVirtual.BackEnd.sln` en Visual Studio
2. Establece `TiendaVirtual.WebApi` como proyecto de inicio
3. Pulsa **F5** o **Ejecutar**
4. Swagger estará disponible en `https://localhost:{puerto}/swagger`

## Endpoints disponibles

### Autenticación — `/api/auth`
- `POST /login` — inicia sesión y devuelve un token JWT
- `POST /register` — registra un nuevo usuario con rol Cliente

### Productos — `/api/product`
- `GET /` — obtiene todos los productos activos
- `GET /{id}` — obtiene un producto por su ID
- `GET /category/{categoryId}` — obtiene productos filtrados por categoría
- `POST /` — crea un nuevo producto *(requiere rol Admin)*
- `PUT /{id}` — actualiza un producto existente *(requiere rol Admin)*
- `DELETE /{id}` — desactiva un producto (borrado lógico) *(requiere rol Admin)*

## Autor

Gonzalo López Luque — IES SOTERO HERNÁNDEZ — DAW 2025/2026