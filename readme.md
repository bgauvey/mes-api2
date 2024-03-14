# MES-API 4.0

## Libraries
___
**BOL.API.Domain** - plain old model classes; Classes are EF database entities.

*Namespaces*
- Core - Contains things like Ent, Attr, Sched...
- Security - Contains Session, UserName, Priv, all things security

**BOL.API.Repository** - Data access layer.  This library is the only way to get to the database.

*Namespaces*
- Core
- Security

**BOL.API.Services** - Business logic; it does not have access to the database, must use repositories

*Services*
- Authorization

**mes-api** - The web service.  Uses JWT token security. All requests are secured

*Routes*
- Auth
    - login