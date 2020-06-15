# Brasil Vinil API .NET

Esse projeto de faculdade � a cria��o de uma API em C# para um ambiente de compras de discos de vinil com integra��o ao SQL Server.

##Instalar

Para instalar o projeto � necess�rio:
- [Visual Studio 2019 Community](https://visualstudio.microsoft.com/pt-br/downloads/)
- [SQL Server Developer](https://www.microsoft.com/pt-br/sql-server/sql-server-downloads)

Opcional:
- [SQL Server Management Studio(SSMS)](https://docs.microsoft.com/pt-br/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver15)

##Build

Para rodar o projeto � necess�rio primeiramente criar o banco de dados presente no arquivo "projeto query.sql" no SQL Server.

Ap�s a cria��o das tabelas no banco ser� necess�rio adicionar o todos projetos a inicializa��o:
- Clique direito na "Solu��o 'Projeto'(5 de 5 projetos)"
- Abrir Propriedades
- Escolher Propriedades Comuns > Projeto de Inicializa��o
- Selecionar "V�rios projetos de inicializa��o"
- Mudar a a��o de todos para "Iniciar"
- Aplicar e Ok

Com isso � apenas necess�rio clicar no bot�o de iniciar e o site ser� iniciado no navegador padr�o.

##Configura��es

O site atualmente n�o est� cadastrando produtos, portanto para ter todas as fun��es � necess�rio pelo menos um produto e fornecedor cadastrado no banco de dados, recomendado tbm inserir estoques para possibilitar o teste de pedidos.