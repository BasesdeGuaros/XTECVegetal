using System;
using System.Collections.Generic;

#nullable disable

namespace XTECVegetalAPI.Models
{
    public partial class Noticium
    {
        public Noticium()
        {
            NoticiaDeCursos = new HashSet<NoticiaDeCurso>();
        }

        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public string Titulo { get; set; }
        public string Mensaje { get; set; }
        public DateTime? Fecha { get; set; }
        public int? Autor { get; set; }

        public virtual Usuario AutorNavigation { get; set; }
        public virtual ICollection<NoticiaDeCurso> NoticiaDeCursos { get; set; }
    }
}
