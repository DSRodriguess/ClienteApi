# Cliente API

API RESTful para gerenciar clientes e seus endereços.

## Endpoints

- `GET /clientes`
- `GET /clientes/{id}`
- `POST /clientes`
- `PUT /clientes/{id}`
- `DELETE /clientes/{id}`

Cada cliente tem:
- Nome (obrigatório)
- Email (único e obrigatório)
- Telefone (opcional)
- Um único endereço com:
  - Rua
  - Número
  - Cidade
  - Estado
  - CEP

## Tecnologias

- ASP.NET Core 6+
- Entity Framework Core (In-Memory Database)
- AutoMapper
- DDD (Domain-Driven Design)
- Swagger UI