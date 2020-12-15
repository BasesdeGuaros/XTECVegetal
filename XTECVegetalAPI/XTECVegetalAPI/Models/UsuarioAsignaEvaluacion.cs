using System;
using System.Collections.Generic;

#nullable disable

namespace XTECVegetalAPI.Models
{
    public partial class UsuarioAsignaEvaluacion
    {
        public int IdUsuario { get; set; }
        public int IdEvaluacion { get; set; }

        public virtual Evaluacion IdEvaluacionNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
