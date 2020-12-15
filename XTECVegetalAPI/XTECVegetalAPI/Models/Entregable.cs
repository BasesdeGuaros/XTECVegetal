using System;
using System.Collections.Generic;

#nullable disable

namespace XTECVegetalAPI.Models
{
    public partial class Entregable
    {
        public Entregable()
        {
            UsuarioSubeEntregables = new HashSet<UsuarioSubeEntregable>();
        }

        public int Id { get; set; }
        public int IdEvaluacion { get; set; }
        public string Nombre { get; set; }
        public byte[] Archivo { get; set; }
        public string Observaciones { get; set; }
        public int? Nota { get; set; }
        public int? NotaPublica { get; set; }

        public virtual Evaluacion IdEvaluacionNavigation { get; set; }
        public virtual ICollection<UsuarioSubeEntregable> UsuarioSubeEntregables { get; set; }
    }
}
