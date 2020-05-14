using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class Cadastrousuario
    {
        public int Idusuario { get; set; }
        public string Celular { get; set; }
        public string Cep { get; set; }
        public string Cidade { get; set; }
        public string Complemento { get; set; }
        public string Cpf { get; set; }
        public string Datanasc { get; set; }
        public string Email { get; set; }
        public string Logradouro { get; set; }
        public string Nome { get; set; }
        public string Numero { get; set; }
        public string Senha { get; set; }
        public string Sexo { get; set; }
        public string Sobrenome { get; set; }
        public string Telefone { get; set; }
        public string Uf { get; set; }
        public int? Tipo { get; set; }
    }
}
