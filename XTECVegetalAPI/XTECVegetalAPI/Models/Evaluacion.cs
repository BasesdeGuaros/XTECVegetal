using System;
using System.Collections.Generic;

#nullable disable

namespace XTECVegetalAPI.Models
{
    public partial class Evaluacion
    {
        public Evaluacion()
        {
            Entregables = new HashSet<Entregable>();
            UsuarioAsignaEvaluacions = new HashSet<UsuarioAsignaEvaluacion>();
        }

        public int Id { get; set; }
        public int IdRubro { get; set; }
        public int? Grupal { get; set; }
        public DateTime FechaEntrega { get; set; }
        public string Observaciones { get; set; }
        public byte[] Especificacion { get; set; }
        public int? Porcentaje { get; set; }

        public virtual Rubro IdRubroNavigation { get; set; }
        public virtual ICollection<Entregable> Entregables { get; set; }
        public virtual ICollection<UsuarioAsignaEvaluacion> UsuarioAsignaEvaluacions { get; set; }
    }
}
