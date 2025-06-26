# API de Gerenciamento de Clientes

API RESTful em ASP.NET Core 6 para gerenciar cadastro de clientes com endereços, utilizando os princípios do **Domain-Driven Design (DDD)** e **Entity Framework Core In-Memory Database**.

## Objetivo

Criar uma Web API que permite o gerenciamento de clientes e seus respectivos endereços com os seguintes endpoints:

- `GET /clientes` – Listar todos os clientes  
- `GET /clientes/{id}` – Obter cliente pelo ID  
- `POST /clientes` – Criar novo cliente  
- `PUT /clientes/{id}` – Atualizar cliente existente  
- `DELETE /clientes/{id}` – Remover cliente  

Cada cliente possui:
- Nome (obrigatório)
- Email (único e obrigatório)
- Telefone (opcional)
- Um único endereço com:
  - Rua (obrigatória)
  - Número (obrigatório)
  - Cidade (obrigatória)
  - Estado (obrigatório)
  - CEP (obrigatório)

---

## Tecnologias Utilizadas

- **ASP.NET Core 6**
- **Entity Framework Core** (In-Memory Database)
- **AutoMapper** para mapeamento entre DTOs e Entidades
- **Domain-Driven Design (DDD)** – Separação por camadas: Domain, Application, Infrastructure, API
- **Swagger UI** – Documentação interativa da API

## Estrutura do Projeto


## Como Executar o Projeto

1. **Pré-requisitos:**  
   Instale o [.NET 6 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)

2. **Clone o repositório:**

   ```bash
   git clone https://github.com/seu-usuario/cliente-api.git
   cd cliente-api
   ```

3. **Restaure as dependências:**
   ```bash
   dotnet restore
   ```

4. **Execute a aplicação:**
   ```bash
   dotnet run
   ```

5. **Acesse a documentação Swagger:**  
   [https://localhost:5001/swagger](https://localhost:5001/swagger)


## Exemplo de Requisição 

**Endpoint:** `POST /clientes`

**Body:**

```json
{
  "nome": "João da Silva",
  "email": "joao.silva@email.com",
  "telefone": "(21) 91234-5678",
  "endereco": {
    "rua": "Rua das casas",
    "numero": "123",
    "cidade": "Rio de Janeiro",
    "estado": "RJ",
    "cep": "01234-567"
  }
}
```

