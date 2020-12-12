using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XTECVegetalAPI.Models.Request
{
    public class UsuarioRequest
    {
        public int Id { get; set; }
        public int IdRol { get; set; }

        public virtual Rol IdRolNavigation { get; set; }
        public virtual ICollection<Noticium> Noticia { get; set; }
        public virtual ICollection<PerteneceUsuarioGrupo> PerteneceUsuarioGrupos { get; set; }
        public virtual ICollection<UsuarioAdministraRubro> UsuarioAdministraRubros { get; set; }
        public virtual ICollection<UsuarioAsignaEvaluacion> UsuarioAsignaEvaluacions { get; set; }
        public virtual ICollection<UsuarioCreaElemento> UsuarioCreaElementos { get; set; }
        public virtual ICollection<UsuarioSubeEntregable> UsuarioSubeEntregables { get; set; }
    }
}
