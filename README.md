# Clean Architecture & DDD - .NET Core Application

Este projeto demonstra a aplicação dos princípios de **Clean Architecture** e **Domain-Driven Design (DDD)** em uma aplicação web ASP.NET Core.

## Estrutura do Projeto

O projeto segue a estrutura modular de Clean Architecture com clara separação entre camadas:

```
src/
├── Domain/                          # Camada de Domínio (núcleo)
│   └── CleanArchitecture.Domain/
│       ├── Common/                  # Classes base (Entity, ValueObject, AggregateRoot)
│       ├── Entities/                # Entidades de domínio (Product, Category, Customer)
│       ├── Events/                  # Eventos de domínio
│       ├── Interfaces/              # Interfaces de repositórios
│       └── ValueObjects/            # Value Objects (Money, Address)
│
├── Application/                     # Camada de Aplicação
│   └── CleanArchitecture.Application/
│       ├── Common/                  # Classes comuns (Result, Exceptions)
│       ├── DTOs/                    # Data Transfer Objects
│       ├── Interfaces/              # Interfaces de serviços
│       └── UseCases/                # Implementação dos casos de uso
│
├── Infrastructure/                  # Camada de Infraestrutura
│   └── CleanArchitecture.Infrastructure/
│       ├── Data/                    # DbContext e configurações EF Core
│       └── Repositories/            # Implementação dos repositórios
│
└── Presentation/                    # Camada de Apresentação
    └── CleanArchitecture.API/
        └── Controllers/             # API Controllers
```

## Princípios de Clean Architecture Aplicados

### Regra de Dependência
- As dependências apontam sempre para dentro (em direção ao domínio)
- O domínio não conhece as outras camadas
- A infraestrutura implementa interfaces definidas no domínio

### Separação de Responsabilidades
- **Domain**: Contém a lógica de negócios e regras empresariais
- **Application**: Contém os casos de uso da aplicação
- **Infrastructure**: Contém detalhes de implementação (banco de dados, serviços externos)
- **Presentation**: Contém a interface com o usuário (API REST)

## Conceitos de DDD Implementados

### Entities
Objetos com identidade única que persistem ao longo do tempo:
- `Product`: Produto com nome, descrição, preço e estoque
- `Category`: Categoria de produtos
- `Customer`: Cliente com dados de contato

### Value Objects
Objetos imutáveis definidos pelos seus atributos:
- `Money`: Representa valor monetário com moeda
- `Address`: Representa endereço completo

### Aggregate Roots
Entidades que são raízes de agregados:
- `Product`: Gerencia seu próprio ciclo de vida
- `Customer`: Gerencia endereços e dados pessoais

### Domain Events
Eventos que representam algo que aconteceu no domínio:
- `ProductCreatedEvent`: Disparado quando um produto é criado
- `ProductUpdatedEvent`: Disparado quando um produto é atualizado

### Repository Pattern
Interfaces que abstraem o acesso a dados:
- `IProductRepository`: Operações com produtos
- `ICategoryRepository`: Operações com categorias
- `ICustomerRepository`: Operações com clientes
- `IUnitOfWork`: Gerenciamento de transações

## Como Executar

### Pré-requisitos
- .NET 10.0 SDK ou superior

### Executar a aplicação

```bash
# Restaurar dependências
dotnet restore

# Compilar
dotnet build

# Executar a API
dotnet run --project src/Presentation/CleanArchitecture.API
```

### Acessar a documentação da API

Após iniciar a aplicação, acesse:
- Swagger UI: `https://localhost:7279/swagger` (HTTPS) ou `http://localhost:5220/swagger` (HTTP)

## Endpoints da API

### Products
- `GET /api/products` - Listar todos os produtos
- `GET /api/products/{id}` - Obter produto por ID
- `GET /api/products/active` - Listar produtos ativos
- `GET /api/products/search?name={name}` - Buscar por nome
- `GET /api/products/category/{categoryId}` - Produtos por categoria
- `POST /api/products` - Criar produto
- `PUT /api/products/{id}` - Atualizar produto
- `DELETE /api/products/{id}` - Excluir produto
- `POST /api/products/{id}/activate` - Ativar produto
- `POST /api/products/{id}/deactivate` - Desativar produto

### Categories
- `GET /api/categories` - Listar todas as categorias
- `GET /api/categories/{id}` - Obter categoria por ID
- `GET /api/categories/active` - Listar categorias ativas
- `POST /api/categories` - Criar categoria
- `PUT /api/categories/{id}` - Atualizar categoria
- `DELETE /api/categories/{id}` - Excluir categoria

### Customers
- `GET /api/customers` - Listar todos os clientes
- `GET /api/customers/{id}` - Obter cliente por ID
- `GET /api/customers/active` - Listar clientes ativos
- `GET /api/customers/search?name={name}` - Buscar por nome
- `POST /api/customers` - Criar cliente
- `PUT /api/customers/{id}` - Atualizar cliente
- `DELETE /api/customers/{id}` - Excluir cliente

## Tecnologias Utilizadas

- ASP.NET Core 10.0
- Entity Framework Core 9.0 (InMemory para demonstração)
- Swagger/OpenAPI para documentação
- Padrão Repository e Unit of Work