using System;
using System.Collections.Generic;

#nullable disable

namespace XTECVegetalAPI.Models
{
    public partial class UsuarioAdministraRubro
    {
        public int IdRubro { get; set; }
        public int IdUsuario { get; set; }

        public virtual Rubro IdRubroNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
