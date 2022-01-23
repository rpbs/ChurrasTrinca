# Churras Trinca (agendamento de churrasco da empresa)

Projeto de desafio para empresa ingressar na Trinca

Tecnologias utilizadas:

* .NET Core 5
* C#
* EntityFramework Core
* SQL Server
* Autofact
* AutoMapper
* CQRS
* SOLID
* Mediator
* Xunit
* Moq

Padrão de projeto - Mediator - CRQS

Arquitetura da solução
* ChurrasTrinca - Projeto web, contêm controllers
* Core - Contêm toda regra de negócio, entidades, responses, mappers, queries, commands.
* Infra - Configuração do dbContext e mapeamento de entidades/banco
* TestChurras - Projeto teste usando moq e xnuit
