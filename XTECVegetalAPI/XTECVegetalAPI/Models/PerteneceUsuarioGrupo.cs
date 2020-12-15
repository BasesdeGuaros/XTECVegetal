using System;
using System.Collections.Generic;

#nullable disable

namespace XTECVegetalAPI.Models
{
    public partial class PerteneceUsuarioGrupo
    {
        public int IdGrupo { get; set; }
        public int IdUsuario { get; set; }

        public virtual Grupo IdGrupoNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
