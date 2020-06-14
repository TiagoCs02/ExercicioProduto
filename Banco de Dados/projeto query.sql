Create database Projeto;

use Projeto;

Create table cadastrofornecedor(
idFornecedor int not null identity,
ativo char(1) not null,
bairro varchar(50) not null,
cep varchar(9) not null,
cidade varchar(50) not null,
cnpj char(14) not null,
complemento varchar(50),
contato1 varchar(17) not null,
contato2 varchar(17),
email varchar(50) not null unique,
logradouro varchar(50) not null,
nomeempresa varchar(50) not null,
uf char(2) not null,
constraint PK_Forn primary key(idFornecedor));

Create table cadastroproduto(
idProduto int not null identity,
idFornecedor int not null,
nome varchar(50) not null,
artista varchar(50) not null,
categoria varchar(50) not null,
valor decimal(8,2) not null,
estado varchar(5) not null,
descricao varchar(100) not null,
audio varchar(100),
capa varchar(100),
constraint PK_Produto primary key(idProduto),
constraint FK_FornProd foreign key(idFornecedor) references cadastrofornecedor(idFornecedor));

create table cadastrousuario(
idUsuario int not null identity,
celular varchar(17) not null,
cep varchar(9) not null,
cidade varchar(50) not null,
complemento varchar(50),
cpf varchar(26) not null,
datanasc date not null,
email varchar(50) not null,
logradouro varchar(50) not null,
nome varchar(50) not null,
numero varchar(10) not null,
senha varchar(50) not null,
sexo char(1) not null,
sobrenome varchar(50) not null,
telefone varchar(17) not null,
uf char(2) not null,
tipo char(1) not null
constraint PK_User primary key(idUsuario));

create table pedido(
idPedido int not null identity,
idUsuario int not null,
data datetime not null,
status varchar(10) not null,
valorTotal decimal(10,2) not null,
tipo varchar(6) not null,
constraint PK_Pedido primary key(idPedido),
constraint FK_UserPed foreign key(idUsuario) references cadastrousuario(idUsuario));

create table detalhepedido(
idDetPed int not null identity,
idPedido int not null,
idProduto int not null,
quantidade int not null,
constraint PK_DetPed primary key(idDetPed),
constraint FK_PedidoDetPed foreign key(idPedido) references pedido(idPedido),
constraint FK_ProdutoDetPed foreign key(idProduto) references cadastroproduto(idProduto));

create table estoque(
data datetime not null default current_timestamp,
idProduto int not null,
estoqueAtual int not null,
estoqueMin int not null,
constraint PK_Estoque primary key(data),
constraint FK_ProdutoEst foreign key(idProduto) references cadastroproduto(idProduto));

create table movimentacao(
idMovimentacao int not null identity,
idPedido int,
idProduto int not null,
dataNf date,
data datetime not null,
nf varchar(50),
quantidade int not null,
tipo varchar(6) not null,
constraint PK_Movimentacao primary key(idMovimentacao),
constraint FK_PedidoMov foreign key(idPedido) references pedido(idPedido),
constraint FK_ProdutoMov foreign key(idProduto) references cadastroproduto(idProduto));