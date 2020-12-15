using System;
using System.Collections.Generic;

#nullable disable

namespace XTECVegetalAPI.Models
{
    public partial class UsuarioSubeEntregable
    {
        public int IdUsuario { get; set; }
        public int IdEntregable { get; set; }

        public virtual Entregable IdEntregableNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
