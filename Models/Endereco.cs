﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Endereco
    {
        public string Logradouro{ get; set; }
        public string Numero{ get; set; }
        public string Cep { get; set; }
        public string Cidade { get; set; }
        public string Uf { get; set; }
    }
}
