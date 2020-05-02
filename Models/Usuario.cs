using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Usuario
    {
		public int IdUsuario { get; set; }
		public String email { get; set; }
		public String senha { get; set; }
		public String nome { get; set; }
		public String sobrenome { get; set; }
		public String sexo { get; set; }
		public String cpf { get; set; }
		public String telefone { get; set; }
		public String celular { get; set; }
		public String cep { get; set; }
		public String datanasc { get; set; }
		public String uf { get; set; }
		public String logradouro { get; set; }
		public String numero { get; set; }
		public String cidade { get; set; }
		public String complemento { get; set; }
		//private List<Role> permissoes

	}
}
