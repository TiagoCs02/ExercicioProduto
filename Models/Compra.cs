using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Compra
    {
        public Pedido Pedido { get; set; }
        public List<Cadastroproduto> ProdutoList { get; set; }
    }
}
