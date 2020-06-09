using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public partial class Cadastroproduto
    {
        public Cadastroproduto()
        {
            Estoque = new HashSet<Estoque>();
            Movimentacao = new HashSet<Movimentacao>();
        }

        public int IdProduto { get; set; }
        public int IdFornecedor { get; set; }
        public string Nome { get; set; }
        public string Artista { get; set; }
        public string Categoria { get; set; }
        public decimal Valor { get; set; }
        public string Estado { get; set; }
        public string Descricao { get; set; }
        public string Audio { get; set; }
        public string Capa { get; set; }

        public virtual Cadastrofornecedor IdFornecedorNavigation { get; set; }
        public virtual ICollection<Estoque> Estoque { get; set; }
        public virtual ICollection<Movimentacao> Movimentacao { get; set; }

        [NotMapped]
        public int valEstoque { get; set; }
        [NotMapped]
        public int Quantidade { get; set; }
    }
}
