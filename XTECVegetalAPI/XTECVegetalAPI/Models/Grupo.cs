using System;
using System.Collections.Generic;

#nullable disable

namespace XTECVegetalAPI.Models
{
    public partial class Grupo
    {
        public Grupo()
        {
            PerteneceUsuarioGrupos = new HashSet<PerteneceUsuarioGrupo>();
        }

        public int Id { get; set; }
        public int IdCurso { get; set; }

        public virtual Curso IdCursoNavigation { get; set; }
        public virtual ICollection<PerteneceUsuarioGrupo> PerteneceUsuarioGrupos { get; set; }
    }
}
