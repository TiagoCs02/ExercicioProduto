using API.Models;
using Microsoft.EntityFrameworkCore;

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
        public virtual DbSet<CadastrousuarioRole> CadastrousuarioRole { get; set; }
        public virtual DbSet<Detalhepedido> Detalhepedido { get; set; }
        public virtual DbSet<Estoque> Estoque { get; set; }
        public virtual DbSet<Movimentacao> Movimentacao { get; set; }
        public virtual DbSet<Pedido> Pedido { get; set; }
        public virtual DbSet<Role> Role { get; set; }

        /*
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseNpgsql("Host=localhost;Database=projeto;Username=postgres;Password=postgresql");
            }
        }
        */

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cadastrofornecedor>(entity =>
            {
                entity.HasKey(e => e.Idfornecedor)
                    .HasName("cadastrofornecedor_pkey");

                entity.ToTable("cadastrofornecedor");

                entity.Property(e => e.Idfornecedor).HasColumnName("idfornecedor");

                entity.Property(e => e.Ativo)
                    .HasColumnName("ativo")
                    .HasMaxLength(255);

                entity.Property(e => e.Bairro)
                    .HasColumnName("bairro")
                    .HasMaxLength(255);

                entity.Property(e => e.Cep)
                    .HasColumnName("cep")
                    .HasMaxLength(255);

                entity.Property(e => e.Cidade)
                    .HasColumnName("cidade")
                    .HasMaxLength(255);

                entity.Property(e => e.Cnpj)
                    .HasColumnName("cnpj")
                    .HasMaxLength(255);

                entity.Property(e => e.Complemento)
                    .HasColumnName("complemento")
                    .HasMaxLength(255);

                entity.Property(e => e.Contato1)
                    .HasColumnName("contato1")
                    .HasMaxLength(255);

                entity.Property(e => e.Contato2)
                    .HasColumnName("contato2")
                    .HasMaxLength(255);

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(255);

                entity.Property(e => e.Logradouro)
                    .HasColumnName("logradouro")
                    .HasMaxLength(255);

                entity.Property(e => e.Nomeempresa)
                    .HasColumnName("nomeempresa")
                    .HasMaxLength(255);

                entity.Property(e => e.Uf)
                    .HasColumnName("uf")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Cadastroproduto>(entity =>
            {
                entity.HasKey(e => e.Idproduto)
                    .HasName("cadastroproduto_pkey");

                entity.ToTable("cadastroproduto");

                entity.Property(e => e.Idproduto)
                    .HasColumnName("idproduto")
                    .ValueGeneratedNever();

                entity.Property(e => e.Artista)
                    .HasColumnName("artista")
                    .HasMaxLength(255);

                entity.Property(e => e.Audio)
                    .HasColumnName("audio")
                    .HasMaxLength(255);

                entity.Property(e => e.Capa)
                    .HasColumnName("capa")
                    .HasMaxLength(255);

                entity.Property(e => e.Categoria)
                    .HasColumnName("categoria")
                    .HasMaxLength(255);

                entity.Property(e => e.Descricao)
                    .HasColumnName("descricao")
                    .HasMaxLength(255);

                entity.Property(e => e.Estado)
                    .HasColumnName("estado")
                    .HasMaxLength(255);

                entity.Property(e => e.Idfornecedor).HasColumnName("idfornecedor");

                entity.Property(e => e.Nome)
                    .HasColumnName("nome")
                    .HasMaxLength(255);

                entity.Property(e => e.Valor)
                    .HasColumnName("valor")
                    .HasColumnType("numeric(19,2)");

                entity.HasOne(d => d.IdfornecedorNavigation)
                    .WithMany(p => p.Cadastroproduto)
                    .HasForeignKey(d => d.Idfornecedor)
                    .HasConstraintName("fk_sbg1jfg801g8xndmyyyphcl6w");
            });

            modelBuilder.Entity<Cadastrousuario>(entity =>
            {
                entity.HasKey(e => e.Idusuario)
                    .HasName("cadastrousuario_pkey");

                entity.ToTable("cadastrousuario");

                entity.Property(e => e.Idusuario)
                    .HasColumnName("idusuario")
                    .HasDefaultValueSql("nextval('s_cadastrousuario'::regclass)");

                entity.Property(e => e.Celular)
                    .HasColumnName("celular")
                    .HasMaxLength(255);

                entity.Property(e => e.Cep)
                    .HasColumnName("cep")
                    .HasMaxLength(255);

                entity.Property(e => e.Cidade)
                    .HasColumnName("cidade")
                    .HasMaxLength(255);

                entity.Property(e => e.Complemento)
                    .HasColumnName("complemento")
                    .HasMaxLength(255);

                entity.Property(e => e.Cpf)
                    .HasColumnName("cpf")
                    .HasMaxLength(255);

                entity.Property(e => e.Datanasc)
                    .HasColumnName("datanasc")
                    .HasMaxLength(255);

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(255);

                entity.Property(e => e.Logradouro)
                    .HasColumnName("logradouro")
                    .HasMaxLength(255);

                entity.Property(e => e.Nome)
                    .HasColumnName("nome")
                    .HasMaxLength(255);

                entity.Property(e => e.Numero)
                    .HasColumnName("numero")
                    .HasMaxLength(255);

                entity.Property(e => e.Senha)
                    .HasColumnName("senha")
                    .HasMaxLength(255);

                entity.Property(e => e.Sexo)
                    .HasColumnName("sexo")
                    .HasMaxLength(255);

                entity.Property(e => e.Sobrenome)
                    .HasColumnName("sobrenome")
                    .HasMaxLength(255);

                entity.Property(e => e.Telefone)
                    .HasColumnName("telefone")
                    .HasMaxLength(255);

                entity.Property(e => e.Tipo).HasColumnName("tipo");

                entity.Property(e => e.Uf)
                    .HasColumnName("uf")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<CadastrousuarioRole>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("cadastrousuario_role");

                entity.HasIndex(e => e.PermissoesNome)
                    .HasName("uk_b08n0csi7ngjxnnixyfodcl8f")
                    .IsUnique();

                entity.Property(e => e.CadastrousuarioIdusuario).HasColumnName("cadastrousuario_idusuario");

                entity.Property(e => e.PermissoesNome)
                    .IsRequired()
                    .HasColumnName("permissoes_nome")
                    .HasMaxLength(255);

                entity.HasOne(d => d.CadastrousuarioIdusuarioNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.CadastrousuarioIdusuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_75hjyayvrq4e3oknfofwqs6pt");

                entity.HasOne(d => d.PermissoesNomeNavigation)
                    .WithOne()
                    .HasForeignKey<CadastrousuarioRole>(d => d.PermissoesNome)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_b08n0csi7ngjxnnixyfodcl8f");
            });

            modelBuilder.Entity<Detalhepedido>(entity =>
            {
                entity.HasKey(e => new { e.Idpedido, e.Idproduto })
                    .HasName("detalhepedido_pkey");

                entity.ToTable("detalhepedido");

                entity.Property(e => e.Idpedido).HasColumnName("idpedido");

                entity.Property(e => e.Idproduto).HasColumnName("idproduto");

                entity.Property(e => e.Quantidade).HasColumnName("quantidade");

                entity.HasOne(d => d.IdpedidoNavigation)
                    .WithMany(p => p.Detalhepedido)
                    .HasForeignKey(d => d.Idpedido)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_jlqh0wwbrrrkv6n7pqpqxkeke");

                entity.HasOne(d => d.IdprodutoNavigation)
                    .WithMany(p => p.Detalhepedido)
                    .HasForeignKey(d => d.Idproduto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_6vqbx0mtggy6sg8qjnvny3ll4");
            });

            modelBuilder.Entity<Estoque>(entity =>
            {
                entity.HasKey(e => e.Data)
                    .HasName("estoque_pkey");

                entity.ToTable("estoque");

                entity.Property(e => e.Data).HasColumnName("data");

                entity.Property(e => e.Estoqueatual).HasColumnName("estoqueatual");

                entity.Property(e => e.Estoquemin).HasColumnName("estoquemin");

                entity.Property(e => e.Idproduto).HasColumnName("idproduto");

                entity.HasOne(d => d.IdprodutoNavigation)
                    .WithMany(p => p.Estoque)
                    .HasForeignKey(d => d.Idproduto)
                    .HasConstraintName("fk_1qhugkaqn4i6mxsidc47lhh5c");
            });

            modelBuilder.Entity<Movimentacao>(entity =>
            {
                entity.HasKey(e => e.Idmovimentacao)
                    .HasName("movimentacao_pkey");

                entity.ToTable("movimentacao");

                entity.Property(e => e.Idmovimentacao)
                    .HasColumnName("idmovimentacao")
                    .ValueGeneratedNever();

                entity.Property(e => e.Data).HasColumnName("data");

                entity.Property(e => e.Datanf).HasColumnName("datanf");

                entity.Property(e => e.IdpedidoIdpedido).HasColumnName("idpedido_idpedido");

                entity.Property(e => e.IdprodutoIdproduto).HasColumnName("idproduto_idproduto");

                entity.Property(e => e.Nf)
                    .HasColumnName("nf")
                    .HasMaxLength(255);

                entity.Property(e => e.Quantidade).HasColumnName("quantidade");

                entity.Property(e => e.Tipo)
                    .HasColumnName("tipo")
                    .HasMaxLength(255);

                entity.HasOne(d => d.IdpedidoIdpedidoNavigation)
                    .WithMany(p => p.Movimentacao)
                    .HasForeignKey(d => d.IdpedidoIdpedido)
                    .HasConstraintName("fk_etr6nv6w4fp4kxjed9rdcp8ps");

                entity.HasOne(d => d.IdprodutoIdprodutoNavigation)
                    .WithMany(p => p.Movimentacao)
                    .HasForeignKey(d => d.IdprodutoIdproduto)
                    .HasConstraintName("fk_84xi11n9bboxi88r7r6tqokeg");
            });

            modelBuilder.Entity<Pedido>(entity =>
            {
                entity.HasKey(e => e.Idpedido)
                    .HasName("pedido_pkey");

                entity.ToTable("pedido");

                entity.Property(e => e.Idpedido).HasColumnName("idpedido");

                entity.Property(e => e.Data).HasColumnName("data");

                entity.Property(e => e.Idfornecedor).HasColumnName("idfornecedor");

                entity.Property(e => e.Requisitante)
                    .HasColumnName("requisitante")
                    .HasMaxLength(255);

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasMaxLength(255);

                entity.Property(e => e.Valortotal)
                    .HasColumnName("valortotal")
                    .HasColumnType("numeric(19,2)");

                entity.HasOne(d => d.IdfornecedorNavigation)
                    .WithMany(p => p.Pedido)
                    .HasForeignKey(d => d.Idfornecedor)
                    .HasConstraintName("fk_dl6y3xagg8qoh1rt1et7wmnse");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.Nome)
                    .HasName("role_pkey");

                entity.ToTable("role");

                entity.Property(e => e.Nome)
                    .HasColumnName("nome")
                    .HasMaxLength(255);
            });

            modelBuilder.HasSequence("s_cadastroproduto");

            modelBuilder.HasSequence("s_cadastrousuario");

            modelBuilder.HasSequence("s_movimentacao");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
