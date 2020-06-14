using System;
using System.Collections.Generic;

namespace Models
{
    public partial class Detalhepedido
    {
        public int IdDetPed { get; set; }
        public int IdPedido { get; set; }
        public int IdProduto { get; set; }
        public int Quantidade { get; set; }

        public virtual Pedido IdPedidoNavigation { get; set; }
        public virtual Cadastroproduto IdProdutoNavigation { get; set; }
    }
}
