using System;
using System.Collections.Generic;

namespace Models
{
    public partial class Estoque
    {
        public DateTime Data { get; set; }
        public int IdProduto { get; set; }
        public int EstoqueAtual { get; set; }
        public int EstoqueMin { get; set; }

        public virtual Cadastroproduto IdProdutoNavigation { get; set; }
    }
}
