# API de Gerenciamento de Clientes

API RESTful em ASP.NET Core para gerenciar cadastro de clientes com endereços, utilizando os princípios do **Domain-Driven Design (DDD)** e **Entity Framework Core In-Memory Database**.

## Funcionalidades

- Cadastro, leitura, atualização e exclusão de clientes  
- Cada cliente possui um único endereço  
- Validação de campos obrigatórios e formatos (ex: email, CEP)  
- Logs detalhados com `ILogger`  
- AutoMapper para mapeamento entre DTOs e Entidades  
- Banco de dados em memória (EF Core In-Memory Database)


## Tecnologias Utilizadas

- **ASP.NET Core 6+**
- **Entity Framework Core** (In-Memory Database)
- **AutoMapper** para mapeamento entre DTOs e Entidades
- **Domain-Driven Design (DDD)** – Separação por camadas: Domain, Application, Infrastructure, API
- **Swagger UI** – Documentação interativa da API

## Endpoints Disponíveis

| Método | Rota             | Descrição                      |
|--------|------------------|--------------------------------|
| GET    | `/clientes`      | Lista todos os clientes        |
| GET    | `/clientes/{id}` | Busca cliente por ID           |
| POST   | `/clientes`      | Cria novo cliente              |
| PUT    | `/clientes/{id}` | Atualiza cliente existente     |
| DELETE | `/clientes/{id}` | Remove cliente                 |

## Estrutura do Projeto

```bash
ClienteApi/
│
├── Controllers/                  <- Camada API (controllers)
├── Application/                  <- DTOs e serviços
├── Domain/                       <- Entidades e interfaces (DDD)
├── Infrastructure/               <- Contexto EF e repositórios
├── Mappings/                     <- Configurações do AutoMapper
├── Program.cs                    <- Configuração geral da API
└── README.md                     <- Este arquivo
```

## Como Executar o Projeto

**Pré-requisitos:**

   Instale o [.NET SDK 6.0+](https://dotnet.microsoft.com/download/dotnet/6.0)

**Passos**

1. **Clone o repositório:**

   ```bash
   git clone https://github.com/DSRodriguess/ClienteApi.git
   cd cliente-api
   ```

2. **Restaure as dependências:**
   ```bash
   dotnet restore
   ```

3. **Compile e execute a aplicação:**
   ```bash
   dotnet run
   ```

4. **Acesse a documentação Swagger:**  
   [https://localhost:5001/swagger](https://localhost:5001/swagger)


## Exemplo de Uso

Use o Swagger ou ferramentas como **Postman** , **curl** ou **Insomnia** para testar os endpoints.

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

## Melhores Práticas Adicionais
- DDD com separação clara de camadas
- Logging com ILogger
- Validações com DataAnnotations
- Respostas padronizadas (sucesso, erro, validação)
- Documentação com Swagger

## Autor

Desenvolvido por [David Rodrigues](https://github.com/DSRodriguess)

LinkedIn - https://www.linkedin.com/in/davidrodrigues97


