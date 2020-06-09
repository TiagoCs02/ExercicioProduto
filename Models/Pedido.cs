using System;
using System.Collections.Generic;

namespace Models
{
    public partial class Pedido
    {
        public Pedido()
        {
            Movimentacao = new HashSet<Movimentacao>();
        }

        public int IdPedido { get; set; }
        public int IdUsuario { get; set; }
        public DateTime Data { get; set; }
        public string Status { get; set; }
        public decimal ValorTotal { get; set; }
        public string Tipo { get; set; }

        public virtual Cadastrousuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<Movimentacao> Movimentacao { get; set; }
    }
}
