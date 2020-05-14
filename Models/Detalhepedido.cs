using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class Detalhepedido
    {
        public int Idpedido { get; set; }
        public int Idproduto { get; set; }
        public int Quantidade { get; set; }

        public virtual Pedido IdpedidoNavigation { get; set; }
        public virtual Cadastroproduto IdprodutoNavigation { get; set; }
    }
}
