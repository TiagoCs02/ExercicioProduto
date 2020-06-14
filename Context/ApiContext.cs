using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Models;

namespace Context
{
    public partial class ApiContext : DbContext
    {
        public ApiContext()
        {
        }

        public ApiContext(DbContextOptions<ApiContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cadastrofornecedor> Cadastrofornecedor { get; set; }
        public virtual DbSet<Cadastroproduto> Cadastroproduto { get; set; }
        public virtual DbSet<Cadastrousuario> Cadastrousuario { get; set; }
        public virtual DbSet<Detalhepedido> Detalhepedido { get; set; }
        public virtual DbSet<Estoque> Estoque { get; set; }
        public virtual DbSet<Movimentacao> Movimentacao { get; set; }
        public virtual DbSet<Pedido> Pedido { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cadastrofornecedor>(entity =>
            {
                entity.HasKey(e => e.IdFornecedor)
                    .HasName("PK_Forn");

                entity.ToTable("cadastrofornecedor");

                entity.HasIndex(e => e.Email)
                    .HasName("UQ__cadastro__AB6E6164B10D437F")
                    .IsUnique();

                entity.Property(e => e.IdFornecedor).HasColumnName("idFornecedor");

                entity.Property(e => e.Ativo)
                    .IsRequired()
                    .HasColumnName("ativo")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Bairro)
                    .IsRequired()
                    .HasColumnName("bairro")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Cep)
                    .IsRequired()
                    .HasColumnName("cep")
                    .HasMaxLength(9)
                    .IsUnicode(false);

                entity.Property(e => e.Cidade)
                    .IsRequired()
                    .HasColumnName("cidade")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Cnpj)
                    .IsRequired()
                    .HasColumnName("cnpj")
                    .HasMaxLength(14)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Complemento)
                    .HasColumnName("complemento")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Contato1)
                    .IsRequired()
                    .HasColumnName("contato1")
                    .HasMaxLength(17)
                    .IsUnicode(false);

                entity.Property(e => e.Contato2)
                    .HasColumnName("contato2")
                    .HasMaxLength(17)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Logradouro)
                    .IsRequired()
                    .HasColumnName("logradouro")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nomeempresa)
                    .IsRequired()
                    .HasColumnName("nomeempresa")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Uf)
                    .IsRequired()
                    .HasColumnName("uf")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Cadastroproduto>(entity =>
            {
                entity.HasKey(e => e.IdProduto)
                    .HasName("PK_Produto");

                entity.ToTable("cadastroproduto");

                entity.Property(e => e.IdProduto).HasColumnName("idProduto");

                entity.Property(e => e.Artista)
                    .IsRequired()
                    .HasColumnName("artista")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Audio)
                    .HasColumnName("audio")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Capa)
                    .HasColumnName("capa")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Categoria)
                    .IsRequired()
                    .HasColumnName("categoria")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasColumnName("descricao")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasColumnName("estado")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.IdFornecedor).HasColumnName("idFornecedor");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("nome")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Valor)
                    .HasColumnName("valor")
                    .HasColumnType("decimal(8, 2)");

                entity.HasOne(d => d.IdFornecedorNavigation)
                    .WithMany(p => p.Cadastroproduto)
                    .HasForeignKey(d => d.IdFornecedor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FornProd");
            });

            modelBuilder.Entity<Cadastrousuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK_User");

                entity.ToTable("cadastrousuario");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.Celular)
                    .IsRequired()
                    .HasColumnName("celular")
                    .HasMaxLength(17)
                    .IsUnicode(false);

                entity.Property(e => e.Cep)
                    .IsRequired()
                    .HasColumnName("cep")
                    .HasMaxLength(9)
                    .IsUnicode(false);

                entity.Property(e => e.Cidade)
                    .IsRequired()
                    .HasColumnName("cidade")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Complemento)
                    .HasColumnName("complemento")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Cpf)
                    .IsRequired()
                    .HasColumnName("cpf")
                    .HasMaxLength(26)
                    .IsUnicode(false);

                entity.Property(e => e.Datanasc)
                    .HasColumnName("datanasc")
                    .HasColumnType("date");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Logradouro)
                    .IsRequired()
                    .HasColumnName("logradouro")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("nome")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Numero)
                    .IsRequired()
                    .HasColumnName("numero")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasColumnName("senha")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Sexo)
                    .IsRequired()
                    .HasColumnName("sexo")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Sobrenome)
                    .IsRequired()
                    .HasColumnName("sobrenome")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Telefone)
                    .IsRequired()
                    .HasColumnName("telefone")
                    .HasMaxLength(17)
                    .IsUnicode(false);

                entity.Property(e => e.Tipo)
                    .IsRequired()
                    .HasColumnName("tipo")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Uf)
                    .IsRequired()
                    .HasColumnName("uf")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Detalhepedido>(entity =>
            {
                entity.HasKey(e => e.IdDetPed)
                    .HasName("PK_DetPed");

                entity.ToTable("detalhepedido");

                entity.Property(e => e.IdDetPed).HasColumnName("idDetPed");

                entity.Property(e => e.IdPedido).HasColumnName("idPedido");

                entity.Property(e => e.IdProduto).HasColumnName("idProduto");

                entity.Property(e => e.Quantidade).HasColumnName("quantidade");

                entity.HasOne(d => d.IdPedidoNavigation)
                    .WithMany(p => p.Detalhepedido)
                    .HasForeignKey(d => d.IdPedido)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PedidoDetPed");

                entity.HasOne(d => d.IdProdutoNavigation)
                    .WithMany(p => p.Detalhepedido)
                    .HasForeignKey(d => d.IdProduto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProdutoDetPed");
            });

            modelBuilder.Entity<Estoque>(entity =>
            {
                entity.HasKey(e => e.Data)
                    .HasName("PK_Estoque");

                entity.ToTable("estoque");

                entity.Property(e => e.Data)
                    .HasColumnName("data")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.EstoqueAtual).HasColumnName("estoqueAtual");

                entity.Property(e => e.EstoqueMin).HasColumnName("estoqueMin");

                entity.Property(e => e.IdProduto).HasColumnName("idProduto");

                entity.HasOne(d => d.IdProdutoNavigation)
                    .WithMany(p => p.Estoque)
                    .HasForeignKey(d => d.IdProduto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProdutoEst");
            });

            modelBuilder.Entity<Movimentacao>(entity =>
            {
                entity.HasKey(e => e.IdMovimentacao)
                    .HasName("PK_Movimentacao");

                entity.ToTable("movimentacao");

                entity.Property(e => e.IdMovimentacao).HasColumnName("idMovimentacao");

                entity.Property(e => e.Data)
                    .HasColumnName("data")
                    .HasColumnType("datetime");

                entity.Property(e => e.DataNf)
                    .HasColumnName("dataNf")
                    .HasColumnType("date");

                entity.Property(e => e.IdPedido).HasColumnName("idPedido");

                entity.Property(e => e.IdProduto).HasColumnName("idProduto");

                entity.Property(e => e.Nf)
                    .HasColumnName("nf")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Quantidade).HasColumnName("quantidade");

                entity.Property(e => e.Tipo)
                    .IsRequired()
                    .HasColumnName("tipo")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdPedidoNavigation)
                    .WithMany(p => p.Movimentacao)
                    .HasForeignKey(d => d.IdPedido)
                    .HasConstraintName("FK_PedidoMov");

                entity.HasOne(d => d.IdProdutoNavigation)
                    .WithMany(p => p.Movimentacao)
                    .HasForeignKey(d => d.IdProduto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProdutoMov");
            });

            modelBuilder.Entity<Pedido>(entity =>
            {
                entity.HasKey(e => e.IdPedido)
                    .HasName("PK_Pedido");

                entity.ToTable("pedido");

                entity.Property(e => e.IdPedido).HasColumnName("idPedido");

                entity.Property(e => e.Data)
                    .HasColumnName("data")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnName("status")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Tipo)
                    .IsRequired()
                    .HasColumnName("tipo")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.ValorTotal)
                    .HasColumnName("valorTotal")
                    .HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Pedido)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserPed");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
