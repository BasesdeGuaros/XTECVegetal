using System;
using System.Collections.Generic;

#nullable disable

namespace XTECVegetalAPI.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Noticia = new HashSet<Noticium>();
            PerteneceUsuarioGrupos = new HashSet<PerteneceUsuarioGrupo>();
            UsuarioAdministraRubros = new HashSet<UsuarioAdministraRubro>();
            UsuarioAsignaEvaluacions = new HashSet<UsuarioAsignaEvaluacion>();
            UsuarioCreaElementos = new HashSet<UsuarioCreaElemento>();
            UsuarioSubeEntregables = new HashSet<UsuarioSubeEntregable>();
        }

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
