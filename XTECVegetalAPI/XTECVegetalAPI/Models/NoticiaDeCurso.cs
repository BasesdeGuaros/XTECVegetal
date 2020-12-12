using System;
using System.Collections.Generic;

#nullable disable

namespace XTECVegetalAPI.Models
{
    public partial class NoticiaDeCurso
    {
        public int IdNoticia { get; set; }
        public int IdCurso { get; set; }

        public virtual Curso IdCursoNavigation { get; set; }
        public virtual Noticium IdNoticiaNavigation { get; set; }
    }
}
