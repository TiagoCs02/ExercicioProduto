use projeto;

insert into cadastrofornecedor values('1', 'Bairro1', '00000-000', 'Cidade1', '00000000000000', '', '(11)4444-4444', '(11)94444-4444', 'empresa@email.com', 'Rua 1, 11', 'Empresa1', 'SP');
insert into cadastroproduto values(1, 'ProdutoInicial', 'Artista1', 'Rock', 205.50, 'Novo', 'Descri��o do produto inicial que ser� usado como teste', '', '1.jpg');
insert into cadastroproduto values(1, 'Produto2', 'Artista1', 'Rock', 300.70, 'Novo', 'Descri��o do produto 2', '', '2.jpg');
insert into cadastroproduto values(1, 'Produto3', 'Artista2', 'MPB', 25.20, 'Usado', 'Descri��o do glorioso produto 3', '', '3.jpg');
insert into cadastroproduto values(1, 'Produto4', 'Artista2', 'Samba', 275.30, 'Usado', 'Descri��o bem gen�rica do produto 4', '', '4.jpg');
insert into cadastroproduto values(1, 'Produto5', 'Artista3', 'Pop', 185.50, 'Novo', 'Descri��o completamente original do grandississimo e poderoso produto 5, que seus feitos sejam sempre lembrados como o �nico produto com o n�mero 5 em seu nome, apesar de possuir um nome bem comum entre seus companheiros produtos', '', '5.jpg');
insert into cadastroproduto values(1, 'Produto6', 'Artista3', 'Rock', 60.70, 'Usado', 'Descri��o do produto 6, ele n�o gosta do 5', '', '6.jpg');
insert into cadastroproduto values(1, 'Produto7', 'Artista1', 'Pop', 175.80, 'Novo', 'Descri��o do produto 7, que possui parentensco com o produto 1, por�m nunca se encontraram', '', '7.jpg');
insert into cadastroproduto values(1, 'Produto8', 'Artista5', 'Samba', 80.30, 'Novo', 'Descri��o gen�rica porque o produto 8 merece', '', '8.jpg');
insert into cadastroproduto values(1, 'Produto9', 'Artista4', 'MPB', 20.50, 'Usado', 'Descri��o do produto 9...', '', '9.jpg');
insert into cadastroproduto values(1, 'ProdutoFinal', 'Artista1', 'Rock', 175.50, 'Novo', 'Descri��o do produto Final, que possui parentensco com o produto Inicial, por�m nunca se encontraram fora de reuni�es de fam�lia, vulgos filtros por categoria', '', '10.jpg');
select * from cadastroproduto;
insert into estoque values(current_timestamp, 1, 300, 10);
insert into estoque values(current_timestamp, 2, 39, 40);
insert into estoque values(current_timestamp, 3, 30, 30);
insert into estoque values(current_timestamp, 4, 5, 10);
insert into estoque values(current_timestamp, 5, 40, 10);
insert into estoque values(current_timestamp, 6, 39, 10);
insert into estoque values(current_timestamp, 7, 200, 5);
insert into estoque values(current_timestamp, 8, 30, 5);
insert into estoque values(current_timestamp, 9, 40, 3);
insert into estoque values(current_timestamp, 10, 8, 3);