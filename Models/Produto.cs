using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Produto
    {
        public int IdProduto { get; set; }
        public string Nome { get; set; }
        public string Artista { get; set; }
        public string Categoria { get; set; }
        public decimal Valor { get; set; }
        public string Estado { get; set; }

    }
}
