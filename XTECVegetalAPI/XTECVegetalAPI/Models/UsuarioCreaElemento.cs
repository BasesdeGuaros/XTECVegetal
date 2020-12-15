using System;
using System.Collections.Generic;

#nullable disable

namespace XTECVegetalAPI.Models
{
    public partial class UsuarioCreaElemento
    {
        public int IdUsuario { get; set; }
        public int IdElemento { get; set; }

        public virtual Elemento IdElementoNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
