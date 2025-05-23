# XAlgiz

API RESTful desenvolvida em ASP.NET Core para cadastro de clientes, serviços e emissão de notas fiscais. Utiliza
autenticação JWT, FluentValidation para validações, EF Core com banco em memória e está conteinerizada via Docker.

## 🚀 Funcionalidades

* Login com autenticação JWT
* Cadastro de clientes
* Cadastro de serviços vinculados a clientes
* Emissão de notas fiscais para serviços cadastrados
* Validação robusta de entrada com FluentValidation
* Documentação interativa via Swagger

## 🛠️ Como executar

### Pré-requisitos

* [.NET 8 SDK](https://dotnet.microsoft.com/download)
* [Docker e Docker Compose](https://docs.docker.com/get-docker/)

### Rodando com Docker

```bash
docker-compose up --build
```

Acesse a documentação Swagger em: [http://localhost:5000/swagger](http://localhost:5000/swagger)

### Rodando localmente (sem Docker)

```bash
dotnet build
dotnet run
```

## 🔐 Autenticação

Faça login via `POST /login` com as credenciais fixas:

```json
{
  "user": "admin",
  "password": "123456"
}
```

O token JWT retornado deve ser usado como `Bearer Token` no cabeçalho das requisições autenticadas.

## 📦 Endpoints principais

| Método | Rota             | Descrição                     |
|--------|------------------|-------------------------------|
| POST   | `/login`         | Autentica e retorna token JWT |
| POST   | `/clientes`      | Cadastra novo cliente         |
| POST   | `/servicos`      | Cadastra novo serviço         |
| POST   | `/notas-fiscais` | Emite nota fiscal             |

Todos os endpoints (exceto `/login`) requerem autenticação JWT.

## 👨‍💻 Para desenvolvedores

### Estrutura do Projeto

* `AppDbContext`: Contexto EF Core com entidades `Cliente`, `Servico`, `NotaFiscal`
* `Services`: Contêm lógica de negócios
* `Endpoints`: Extensões que mapeiam rotas HTTP
* `Validators`: Validação com FluentValidation
* `JwtSettings`: Geração de chave secreta para tokens

### Boas práticas aplicadas

* Arquitetura enxuta com endpoints minimalistas
* Validação declarativa
* Tratamento de exceções
* Regras de negócio encapsuladas em serviços

## 🧩 Próximos passos

* [ ] Persistência com banco relacional (ex: PostgreSQL)
* [ ] Implementação de endpoints `GET`, `PUT`, `DELETE` para clientes e serviços
* [ ] Cadastro e gerenciamento de usuários
* [ ] Integração com IdentityServer ou ASP.NET Core Identity
* [ ] Interface web para consumo da API (ex: Blazor, React)
* [ ] Logging estruturado e monitoramento
* [ ] Testes automatizados (unitários e integração)
