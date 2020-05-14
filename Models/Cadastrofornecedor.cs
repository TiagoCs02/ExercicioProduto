using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class Cadastrofornecedor
    {
        public Cadastrofornecedor()
        {
            Cadastroproduto = new HashSet<Cadastroproduto>();
            Pedido = new HashSet<Pedido>();
        }

        public int Idfornecedor { get; set; }
        public string Ativo { get; set; }
        public string Bairro { get; set; }
        public string Cep { get; set; }
        public string Cidade { get; set; }
        public string Cnpj { get; set; }
        public string Complemento { get; set; }
        public string Contato1 { get; set; }
        public string Contato2 { get; set; }
        public string Email { get; set; }
        public string Logradouro { get; set; }
        public string Nomeempresa { get; set; }
        public string Uf { get; set; }

        public virtual ICollection<Cadastroproduto> Cadastroproduto { get; set; }
        public virtual ICollection<Pedido> Pedido { get; set; }
    }
}
