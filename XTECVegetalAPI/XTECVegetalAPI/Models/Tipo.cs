using System;
using System.Collections.Generic;

#nullable disable

namespace XTECVegetalAPI.Models
{
    public partial class Tipo
    {
        public Tipo()
        {
            Elementos = new HashSet<Elemento>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Elemento> Elementos { get; set; }
    }
}
