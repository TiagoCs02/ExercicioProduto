# Brasil Vinil API .NET

Esse projeto de faculdade é a criação de uma API em C# para um ambiente de compras de discos de vinil com integração ao SQL Server.

##Instalar

Para instalar o projeto é necessário:
- [Visual Studio 2019 Community](https://visualstudio.microsoft.com/pt-br/downloads/)
- [SQL Server Developer](https://www.microsoft.com/pt-br/sql-server/sql-server-downloads)

Opcional:
- [SQL Server Management Studio(SSMS)](https://docs.microsoft.com/pt-br/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver15)

##Build

Para rodar o projeto é necessário primeiramente criar o banco de dados presente no arquivo "projeto query.sql" no SQL Server.

Após a criação das tabelas no banco será necessário adicionar o todos projetos a inicialização:
- Clique direito na "Solução 'Projeto'(5 de 5 projetos)"
- Abrir Propriedades
- Escolher Propriedades Comuns > Projeto de Inicialização
- Selecionar "Vários projetos de inicialização"
- Mudar a ação de todos para "Iniciar"
- Aplicar e Ok

Com isso é apenas necessário clicar no botão de iniciar e o site será iniciado no navegador padrão.

##Configurações

O site atualmente não está cadastrando produtos, portanto para ter todas as funções é necessário pelo menos um produto e fornecedor cadastrado no banco de dados, recomendado tbm inserir estoques para possibilitar o teste de pedidos.