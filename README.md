# Tech Challenge 03 - Card game utilizando API d google e com testes automatizados

# Solução uma Aplicações ASP.NET Core, utilizando Framework .NET Core 6 e NUnit Framework para Testes 
# Objetivos: Criar uma aplicação, utilizar pipelines para deployment com execução de tests unitários e de integração para validação e com a configuração de app insights na Azure

Aplicação - Card Game
Web App ASP.Net core utilizando Razor Pages para aprsentar telas de criação de Players, Cards e Batalhas entre dois cards.
Cada uma dessas classes (Player, Baralho, Card e Batalha) são controlados pelas classes Razor para criar, deletar, ler e editar os registros.
Há uma única classe Repository que faz a conexão com o Banco de dados para todas as classes.
A classe Card se comunica comunica com uma API do Google para gerar uma imagem para o card com base em uma pesquisa direcionada.
O link dessa imagem também pode ser alterado pelo usuário ou ele pode solicitar uma nova geração da busca.
A idéia inicial do projeto era utilziar uma API de geração de imagens do DALL-E, mas a conta expirou durante o projeto
Banco de dados utilizado é um Azure SQL Server e a modelagem foi configurada utilizando o Entity Framework Core

Testes automatizados
Foram criadas 6 classes de testes, com 23 casos de testes unitários no total e uma classe 1 teste de integração com um caso de teste.
Os testes unitários avaliam se a criação de Cards e Players está validando corretamente os atributos de Nomes e CPF, para que os registros não possam ser criados incorretamente.
O teste de integração avalia de a conexão com a API do google, utilizada na geraçãod e imagens, está ocorrendo corretamente com retorno 200.
Todos os 23 casos de testes são executados automaticamente pela pipeline no estágio de QA

Próximos passsos:
- Configurar o Indentity para validação do usuário
- Configurar a opção do usuário gerar a imagem do card a partir de uma IA
- Melhorar a UI do sistema

https://www.youtube.com/watch?v=EckrziCgEwk
