using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class Estoque
    {
        public DateTime Data { get; set; }
        public int Estoqueatual { get; set; }
        public int Estoquemin { get; set; }
        public int? Idproduto { get; set; }

        public virtual Cadastroproduto IdprodutoNavigation { get; set; }
    }
}
