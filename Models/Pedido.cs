using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class Pedido
    {
        public Pedido()
        {
            Detalhepedido = new HashSet<Detalhepedido>();
            Movimentacao = new HashSet<Movimentacao>();
        }

        public int Idpedido { get; set; }
        public DateTime? Data { get; set; }
        public string Requisitante { get; set; }
        public string Status { get; set; }
        public decimal? Valortotal { get; set; }
        public int? Idfornecedor { get; set; }

        public virtual Cadastrofornecedor IdfornecedorNavigation { get; set; }
        public virtual ICollection<Detalhepedido> Detalhepedido { get; set; }
        public virtual ICollection<Movimentacao> Movimentacao { get; set; }
    }
}
