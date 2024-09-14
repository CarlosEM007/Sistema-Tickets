# Sistema Tickets

Este é um programa desenvolvido em C# e WPF (Windows Presentation Forms) para gerenciar a quantidade de tickets de refeição distribuídos para os funcionários de uma empresa.

---

## 🌱 Sobre o projeto

Este sistema foi desenvolvido com C# e WPF para realizar o controle dos tickets de refeição em uma empresa. Ele permite realizar operações de CRUD (Create, Read, Update, Delete) no banco de dados MySQL, oferecendo uma interface simples e intuitiva.

---

# Funcionalidades principais

- **Tabela de funcionários e tickets:** O sistema exibe uma tabela com as informações dos funcionários e os tickets distribuídos para cada um. Acima da tabela, há dois botões para acessar as respectivas tabelas.  
  - **Clique simples:** Ao clicar em uma linha, o sistema filtra e exibe o total de tickets associados ao funcionário selecionado.  
  - **Clique duplo:** Ao clicar duas vezes, uma tela é aberta para editar as informações da linha selecionada, e as alterações são salvas diretamente no banco de dados.

- **Ícones de ação:**
  - **Lápis:** Permite editar um funcionário, caso o ID seja conhecido.
  - **Adicionar (+):** Permite adicionar novos funcionários ou tickets ao banco de dados.
  - **Atualizar:** Limpa todos os filtros e atualiza a tabela com os dados mais recentes.
  - **Filtro por data:** No canto superior direito, você pode filtrar as informações de acordo com a data.

- **Validação de dados:** O sistema garante que todos os dados inseridos ou editados passem por uma verificação, evitando erros como a inclusão de CPFs inválidos (com letras) ou a duplicação de CPFs já cadastrados.

---

# Como usar/testar o programa (IMPORTANTE)

### Requisitos:
- Visual Studio 2022
- MySQL com o backup do banco de dados
- Arquivo ZIP com o projeto

### Passos para executar:
1. Instale o Visual Studio 2022.
2. Abra a IDE e selecione "Continuar sem código".
3. No menu superior, vá em **Arquivo > Abrir > Projeto/Solução** e selecione o arquivo `SistemaTickets.sln` a partir do ZIP extraído.
4. Para configurar o banco de dados:
   - Importe o backup no MySQL através de **Server > Import Data**.
   - No projeto, navegue até **Data > DbContext.cs** e atualize a `connectionString` com as credenciais do seu MySQL.
