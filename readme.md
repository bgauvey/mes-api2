# MES-API 4.0

## Libraries
___
**BOL.API.Domain** - plain old model classes; Classes are EF database entities.
**BOL.API.Repository** - Data access
**BOL.API.Services** - Business logic; it does not have access to the database, must use repositories
**mes-api** - The web service.  Uses JWT token security. All requests are secured

