using System;
using System.Collections.Generic;

#nullable disable

namespace XTECVegetalAPI.Models
{
    public partial class Curso
    {
        public Curso()
        {
            Grupos = new HashSet<Grupo>();
            NoticiaDeCursos = new HashSet<NoticiaDeCurso>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Carrera { get; set; }
        public int? Creditos { get; set; }
        public int Semestre { get; set; }

        public virtual Semestre SemestreNavigation { get; set; }
        public virtual ICollection<Grupo> Grupos { get; set; }
        public virtual ICollection<NoticiaDeCurso> NoticiaDeCursos { get; set; }
    }
}
