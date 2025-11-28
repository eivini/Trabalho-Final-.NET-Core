# Trabalho Final - .NET Core + Clean Architecture

Sistema CRUD de gerenciamento de Editoras e Mangás desenvolvido em .NET 8 com Clean Architecture e Domain-Driven Design (DDD).

## Arquitetura

O projeto está organizado em 4 camadas:

- **TrabalhoFinal.Domain** - Entidades, regras de negócio e validações personalizadas
- **TrabalhoFinal.Application** - ViewModels, interfaces e serviços de aplicação
- **TrabalhoFinal.Infrastructure** - Repositórios, Entity Framework Core e migrations
- **TrabalhoFinal.Web** - Controllers MVC e Views Razor

## Pré-requisitos

- .NET 8 SDK
- Docker e Docker Compose

## Como Executar o Projeto

### 1. Iniciar o banco de dados SQL Server

```bash
docker-compose up -d
```

Aguarde alguns segundos até o SQL Server iniciar completamente.

### 2. Criar as tabelas no banco de dados

**Opção A** - Executando o SQL direto (mais simples):
```bash
docker cp create-tables.sql sqlserver-trabalho-final:/create-tables.sql
docker exec -it sqlserver-trabalho-final /opt/mssql-tools18/bin/sqlcmd -S localhost -U sa -P "SqlServer2022!" -C -i /create-tables.sql
```

**Opção B** - Usando Entity Framework Tools (requer instalação):
```bash
dotnet tool install --global dotnet-ef
dotnet ef database update --project TrabalhoFinal.Infrastructure --startup-project TrabalhoFinal.Web
```

### 3. (Opcional) Inserir dados de exemplo

Para popular o banco com 12 editoras e 48 mangás reais:

```bash
docker cp seed-data.sql sqlserver-trabalho-final:/seed-data.sql
docker exec -it sqlserver-trabalho-final /opt/mssql-tools18/bin/sqlcmd -S localhost -U sa -P "SqlServer2022!" -C -i /seed-data.sql
```

### 4. Executar a aplicação

```bash
dotnet run --project TrabalhoFinal.Web
```

A aplicação estará disponível em: http://localhost:5214

## Tecnologias Utilizadas

- .NET 8
- ASP.NET Core MVC
- Entity Framework Core 8
- SQL Server 2022 (Docker)
- Mapster (mapeamento objeto-objeto)
- Bootstrap 5 (tema escuro personalizado)
- jQuery (busca AJAX)

## Estrutura do Projeto

```
TrabalhoFinal/
├── TrabalhoFinal.Domain/          # Entidades e validações
├── TrabalhoFinal.Application/     # ViewModels e interfaces
├── TrabalhoFinal.Infrastructure/  # Repositórios e DbContext
├── TrabalhoFinal.Web/            # Controllers e Views
├── docker-compose.yml            # Configuração do SQL Server
├── seed-data.sql                 # Dados de exemplo
└── TrabalhoFinal.sln            # Solution
```

## Requisitos Implementados

- Clean Architecture com 4 camadas separadas
- Relacionamento 1:N (Editora possui muitos Mangás)
- Chave estrangeira explícita no EF Core
- Mapeamento com Mapster
- CRUD completo para Editoras e Mangás
- 2 validações personalizadas (AnoFuturoAttribute e PrecoMinimoAttribute)
- Busca dinâmica com AJAX sem recarregar a página
- Injeção de Dependências (DI/IoC)

## Connection String

Configurada em `appsettings.json`:

```
Server=localhost,1433;Database=TrabalhoFinalDb;User Id=sa;Password=SqlServer2022!;TrustServerCertificate=True
```

## Comandos Úteis

Parar o banco de dados:
```bash
docker-compose down
```

Ver logs do SQL Server:
```bash
docker-compose logs -f sqlserver
```

Criar nova migration:
```bash
dotnet ef migrations add NomeDaMigration --project TrabalhoFinal.Infrastructure --startup-project TrabalhoFinal.Web
```
