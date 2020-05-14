using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class CadastrousuarioRole
    {
        public int CadastrousuarioIdusuario { get; set; }
        public string PermissoesNome { get; set; }

        public virtual Cadastrousuario CadastrousuarioIdusuarioNavigation { get; set; }
        public virtual Role PermissoesNomeNavigation { get; set; }
    }
}
