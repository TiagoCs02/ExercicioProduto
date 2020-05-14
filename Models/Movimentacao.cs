using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class Movimentacao
    {
        public int Idmovimentacao { get; set; }
        public DateTime? Datanf { get; set; }
        public DateTime? Data { get; set; }
        public string Nf { get; set; }
        public int Quantidade { get; set; }
        public string Tipo { get; set; }
        public int? IdpedidoIdpedido { get; set; }
        public int? IdprodutoIdproduto { get; set; }

        public virtual Pedido IdpedidoIdpedidoNavigation { get; set; }
        public virtual Cadastroproduto IdprodutoIdprodutoNavigation { get; set; }
    }
}
