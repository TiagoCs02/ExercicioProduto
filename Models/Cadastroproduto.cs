using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class Cadastroproduto
    {
        public Cadastroproduto()
        {
            Detalhepedido = new HashSet<Detalhepedido>();
            Estoque = new HashSet<Estoque>();
            Movimentacao = new HashSet<Movimentacao>();
        }

        public int Idproduto { get; set; }
        public string Artista { get; set; }
        public string Categoria { get; set; }
        public string Descricao { get; set; }
        public string Estado { get; set; }
        public string Nome { get; set; }
        public string Audio { get; set; }
        public string Capa { get; set; }
        public decimal? Valor { get; set; }
        public int? Idfornecedor { get; set; }

        public virtual Cadastrofornecedor IdfornecedorNavigation { get; set; }
        public virtual ICollection<Detalhepedido> Detalhepedido { get; set; }
        public virtual ICollection<Estoque> Estoque { get; set; }
        public virtual ICollection<Movimentacao> Movimentacao { get; set; }
    }
}
