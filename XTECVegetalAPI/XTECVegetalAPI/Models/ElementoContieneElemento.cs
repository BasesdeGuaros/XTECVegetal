using System;
using System.Collections.Generic;

#nullable disable

namespace XTECVegetalAPI.Models
{
    public partial class ElementoContieneElemento
    {
        public int IdElemento { get; set; }
        public int IdElementoC { get; set; }

        public virtual Elemento IdElementoCNavigation { get; set; }
        public virtual Elemento IdElementoNavigation { get; set; }
    }
}
