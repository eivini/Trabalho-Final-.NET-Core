# Desenvolvimento de Sistemas de Informação Avançados I

## Trabalho Final

**Conteúdo:** Sistema CRUD em .NET Core  
**Período:** 2025/02

---

## Descrição

Neste trabalho vamos dar continuidade ao desenvolvimento da **APS2 - Clean Architecture e DDD (Domain Driven Design)**. O objetivo é aprimorar a aplicação web aplicando os princípios de Clean Architecture e os conceitos fundamentais de Domain-Driven Design (DDD). 

O projeto deverá demonstrar uma estrutura modular, organizada e de fácil manutenção, evidenciando a separação clara entre as camadas de **Domínio**, **Aplicação**, **Infraestrutura** e **Apresentação**, seguindo as boas práticas de arquitetura de software.

O tema da aplicação continua livre (pode continuar usando o projeto da APS2 ou criar outro do zero), porém deverá permitir a existência de um relacionamento **1-para-muitos** entre duas entidades principais (por exemplo: Categoria → Produtos, Autor → Livros, Marca → Modelos de Carros).

---

## → Requisitos Obrigatórios

### 1. Estrutura já desenvolvida na APS2

- **Domínio:** entidades, regras e conceitos centrais do negócio.
- **Aplicação:** ViewModels, interfaces, serviços de aplicação.
- **Infraestrutura:** persistência de dados, repositórios concretos, migrations, implementação de factory e demais serviços de acesso a dados.
- **Apresentação:** controllers e views (Razor).

### 2. Relacionamento 1:N obrigatório

- O sistema deve possuir pelo menos uma relação de um para muitos entre duas entidades.
- A modelagem deve refletir corretamente o uso de chave primária e chave estrangeira explícita no arquivo de configuração de entidades do EF Core.

### 3. Mapeamento com Mapster

- Utilizar Mapster para mapear entidades e ViewModels dentro da camada de aplicação, evitando acoplamento direto entre domínio e apresentação.

### 4. Persistência de dados com Entity Framework Core

- Utilizar Microsoft SQL Server como banco de dados.
- Implementar migrations e garantir que o projeto seja totalmente executável.

### 5. CRUD completo

- Todas as entidades principais devem possuir operações de criação, listagem, edição e exclusão.

### 6. Validações básicas e personalizadas

- Implementar no mínimo 2 validações personalizadas (Custom Validation Attributes).
- Utilizar Data Annotations para validação de entrada.

### 7. Busca dinâmica com AJAX

- Implementar uma barra de busca nos itens cadastrados.
- O resultado da busca deve ser carregado dinamicamente usando Ajax, sem recarregar a página completa.

### 8. Injeção de Dependências (DI) e Inversão de Controle (IoC)

- Todos os serviços e repositórios devem ser registrados via DI. O projeto deve utilizar corretamente o princípio da inversão de controle.

### 9. Organização e boas práticas

- Código limpo, organizado e com nomeação apropriada.
- Separação clara entre responsabilidades das camadas.
- Evitar duplicação de lógica.

---

## ⚠️ MUITO IMPORTANTE!!!

O código do projeto deve estar disponível no **GitHub** ou **GitLab** ou **BitBucket**, em um repositório **PÚBLICO** para que o professor consiga acessar e ler tudo que foi implementado, não serão aceitas outras formas de entrega além da citada aqui. 

**Então, favor colocar o link do repositório no campo de respostas da APS.**