using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public partial class Cadastrousuario
    {
        public Cadastrousuario()
        {
            Pedido = new HashSet<Pedido>();
        }

        public int IdUsuario { get; set; }
        public string Celular { get; set; }
        public string Cep { get; set; }
        public string Cidade { get; set; }
        public string Complemento { get; set; }
        public string Cpf { get; set; }
        public DateTime Datanasc { get; set; }
        public string Email { get; set; }
        public string Logradouro { get; set; }
        public string Nome { get; set; }
        public string Numero { get; set; }
        public string Senha { get; set; }
        [NotMapped]
        public string ConfSenha { get; set; }
        public string Sexo { get; set; }
        public string Sobrenome { get; set; }
        public string Telefone { get; set; }
        public string Uf { get; set; }
        public string Tipo { get; set; }

        public virtual ICollection<Pedido> Pedido { get; set; }
    }
}
