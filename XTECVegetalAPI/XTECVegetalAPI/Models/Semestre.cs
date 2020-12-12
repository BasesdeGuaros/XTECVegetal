using System;
using System.Collections.Generic;

#nullable disable

namespace XTECVegetalAPI.Models
{
    public partial class Semestre
    {
        public Semestre()
        {
            Cursos = new HashSet<Curso>();
        }

        public int Id { get; set; }
        public int Periodo { get; set; }
        public int Año { get; set; }

        public virtual ICollection<Curso> Cursos { get; set; }
    }
}
