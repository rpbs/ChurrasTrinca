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

API - ChurrasTrinca

# API
![api](https://user-images.githubusercontent.com/5302986/150795727-14b29ca4-e831-4983-a19d-56713e84d56c.JPG)

# Criando um churras
![criando](https://user-images.githubusercontent.com/5302986/150795809-902aeef3-3172-4f4a-bac4-d0cee39661c1.JPG)

# Listando participantes
![participantes](https://user-images.githubusercontent.com/5302986/150795907-3885f3b5-b158-4aff-bde1-3536d88f9015.JPG)

# Listando churrasco (Individual)
![lista-churracos](https://user-images.githubusercontent.com/5302986/150795996-759a7d5c-ee9b-4175-9635-77d61e43c573.JPG)

# Listando churrasco agendados
![agendados](https://user-images.githubusercontent.com/5302986/150796009-f900d6dd-37a4-4520-bcb3-4253579e5ab6.JPG)

# Remover participante
![removeParticipante](https://user-images.githubusercontent.com/5302986/150796525-4e5eb620-2003-4f9f-8396-0c71b7c0a738.JPG)

