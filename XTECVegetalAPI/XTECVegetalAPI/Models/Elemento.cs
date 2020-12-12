using System;
using System.Collections.Generic;

#nullable disable

namespace XTECVegetalAPI.Models
{
    public partial class Elemento
    {
        public Elemento()
        {
            ElementoContieneElementoIdElementoCNavigations = new HashSet<ElementoContieneElemento>();
            ElementoContieneElementoIdElementoNavigations = new HashSet<ElementoContieneElemento>();
            UsuarioCreaElementos = new HashSet<UsuarioCreaElemento>();
        }

        public int Id { get; set; }
        public int Tipo { get; set; }
        public int? Visualizar { get; set; }
        public string Tamaño { get; set; }
        public byte[] Archivo { get; set; }
        public string Nombre { get; set; }
        public DateTime? FechaCreacion { get; set; }

        public virtual Tipo TipoNavigation { get; set; }
        public virtual ICollection<ElementoContieneElemento> ElementoContieneElementoIdElementoCNavigations { get; set; }
        public virtual ICollection<ElementoContieneElemento> ElementoContieneElementoIdElementoNavigations { get; set; }
        public virtual ICollection<UsuarioCreaElemento> UsuarioCreaElementos { get; set; }
    }
}
