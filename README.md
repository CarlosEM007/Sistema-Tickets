# Sistema Tickets
Programa em C# e WPF (Windows Presentation Forms) criado para gerenciar a quantidade de tickets de refeições entregues para cada funcionário de uma empresa.

<hr>

## 🌱 Utilizando C# e WPF desenvolvi um sistema simples de controle de tickets de refeição em uma empresa.
### O Programa realiza CRUD no banco de dados MySQL.

<hr>

# Principais Funcionálidades:
## Uma tabela com as informações dos funcionários e também dos tickets entregues para cada funcionário, para acessa-las a cima da tabela possui dois botões com suas repectivas tabelas. Caso o usuário clique uma vez em cima de uma linha será filtrado o total de tickets baseado no funcionário da linha selecionada, já caso o usuário clicar duas vezes na linha, vai ser aberto uma tela para editar as informações dessa linha, que será salvo no Banco de dados.

## Já acima da tabela existem 3 ícones, um de "Lápis" que permite editar um funcionário, caso o usuário saiba o ID que deseja editar, um icone de + que permite o usuário adicionar tanto novos tickets quanto funcionários ao banco de dados, e outro para atualizar a tabela, que "Limpa os filtros". Já no canto superior direito é possível filtrar por data.

## Todos os valores, tanto editados quanto adicionados, passam por uma verificação para evitar a inserção de dados inválidos, como, por exemplo, CPF com letras ou inserir CPF's já inseridos anteriormente.

<hr>

# Como usar/testar o programa (IMPORTANTE) 
## Nota: Ao meu ver este é o método mais fácil de se executar o programa.
## Requisitos: Arquivo ZIP, Visual Studio 2022 e MySQL + Backup.
### Instale o Visual studio 2022, após isso, abra a IDE e clique em "Continuar sem código", no canto superior vá em Arquivo > Abrir > Projeto/Solução, e abra o SistemaTickets.sln no arquivo ZIP extraido.
### Para configurar o Banco de dados, baixe o Backup, configure o Mysql, vá em 'Server' > Import Data. Para configurar no programa, vá para a IDE e na pasta Data > DbContext.cs > Mude os valores da string connectionString, colocando as crenciais que você configurou no seu mysql

