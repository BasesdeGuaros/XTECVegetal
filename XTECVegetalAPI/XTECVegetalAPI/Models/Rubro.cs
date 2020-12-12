using System;
using System.Collections.Generic;

#nullable disable

namespace XTECVegetalAPI.Models
{
    public partial class Rubro
    {
        public Rubro()
        {
            Evaluacions = new HashSet<Evaluacion>();
            UsuarioAdministraRubros = new HashSet<UsuarioAdministraRubro>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public int? Porcentaje { get; set; }
        public int? IdElemento { get; set; }

        public virtual ICollection<Evaluacion> Evaluacions { get; set; }
        public virtual ICollection<UsuarioAdministraRubro> UsuarioAdministraRubros { get; set; }
    }
}
