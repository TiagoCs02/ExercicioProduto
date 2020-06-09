using System;
using System.Collections.Generic;

namespace Models
{
    public partial class Movimentacao
    {
        public int IdMovimentacao { get; set; }
        public int? IdPedido { get; set; }
        public int IdProduto { get; set; }
        public DateTime? DataNf { get; set; }
        public DateTime Data { get; set; }
        public string Nf { get; set; }
        public int Quantidade { get; set; }
        public string Tipo { get; set; }

        public virtual Pedido IdPedidoNavigation { get; set; }
        public virtual Cadastroproduto IdProdutoNavigation { get; set; }
    }
}
