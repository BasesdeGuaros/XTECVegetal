using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace XTECVegetalAPI.Models
{
    public partial class XTECDigitalContext : DbContext
    {
        public XTECDigitalContext()
        {
        }

        public XTECDigitalContext(DbContextOptions<XTECDigitalContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Curso> Cursos { get; set; }
        public virtual DbSet<Elemento> Elementos { get; set; }
        public virtual DbSet<ElementoContieneElemento> ElementoContieneElementos { get; set; }
        public virtual DbSet<Entregable> Entregables { get; set; }
        public virtual DbSet<Evaluacion> Evaluacions { get; set; }
        public virtual DbSet<Grupo> Grupos { get; set; }
        public virtual DbSet<NoticiaDeCurso> NoticiaDeCursos { get; set; }
        public virtual DbSet<Noticium> Noticia { get; set; }
        public virtual DbSet<PerteneceUsuarioGrupo> PerteneceUsuarioGrupos { get; set; }
        public virtual DbSet<Rol> Rols { get; set; }
        public virtual DbSet<Rubro> Rubros { get; set; }
        public virtual DbSet<Semestre> Semestres { get; set; }
        public virtual DbSet<Tipo> Tipos { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<UsuarioAdministraRubro> UsuarioAdministraRubros { get; set; }
        public virtual DbSet<UsuarioAsignaEvaluacion> UsuarioAsignaEvaluacions { get; set; }
        public virtual DbSet<UsuarioCreaElemento> UsuarioCreaElementos { get; set; }
        public virtual DbSet<UsuarioSubeEntregable> UsuarioSubeEntregables { get; set; }
        public object Usuario { get; internal set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost; Database=XTECDigital; Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Curso>(entity =>
            {
                entity.ToTable("CURSO");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Carrera)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.SemestreNavigation)
                    .WithMany(p => p.Cursos)
                    .HasForeignKey(d => d.Semestre)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CURSO_SEMESTRE_FK");
            });

            modelBuilder.Entity<Elemento>(entity =>
            {
                entity.ToTable("ELEMENTO");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Archivo).HasMaxLength(1);

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("date")
                    .HasColumnName("Fecha_Creacion");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Tamaño)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.TipoNavigation)
                    .WithMany(p => p.Elementos)
                    .HasForeignKey(d => d.Tipo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ELEMENTO_TIPO_FK");
            });

            modelBuilder.Entity<ElementoContieneElemento>(entity =>
            {
                entity.HasKey(e => new { e.IdElemento, e.IdElementoC })
                    .HasName("ELEMENTO_CONTIENE_PK");

                entity.ToTable("ELEMENTO_CONTIENE_ELEMENTO");

                entity.Property(e => e.IdElemento).HasColumnName("Id_Elemento");

                entity.Property(e => e.IdElementoC).HasColumnName("Id_ElementoC");

                entity.HasOne(d => d.IdElementoNavigation)
                    .WithMany(p => p.ElementoContieneElementoIdElementoNavigations)
                    .HasForeignKey(d => d.IdElemento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ELEMENTO_CONTIENE_TIPO_FK");

                entity.HasOne(d => d.IdElementoCNavigation)
                    .WithMany(p => p.ElementoContieneElementoIdElementoCNavigations)
                    .HasForeignKey(d => d.IdElementoC)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CONTIENE_ELEMENTO_TIPO_FK");
            });

            modelBuilder.Entity<Entregable>(entity =>
            {
                entity.ToTable("ENTREGABLE");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Archivo).HasMaxLength(1);

                entity.Property(e => e.IdEvaluacion).HasColumnName("Id_Evaluacion");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.NotaPublica).HasColumnName("Nota_Publica");

                entity.Property(e => e.Observaciones)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdEvaluacionNavigation)
                    .WithMany(p => p.Entregables)
                    .HasForeignKey(d => d.IdEvaluacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ENTREGABLE_EVALUACION_FK");
            });

            modelBuilder.Entity<Evaluacion>(entity =>
            {
                entity.ToTable("EVALUACION");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Especificacion).HasMaxLength(1);

                entity.Property(e => e.FechaEntrega)
                    .HasColumnType("date")
                    .HasColumnName("Fecha_Entrega");

                entity.Property(e => e.IdRubro).HasColumnName("Id_Rubro");

                entity.Property(e => e.Observaciones)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdRubroNavigation)
                    .WithMany(p => p.Evaluacions)
                    .HasForeignKey(d => d.IdRubro)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("EVALUACION_RUBRO_FK");
            });

            modelBuilder.Entity<Grupo>(entity =>
            {
                entity.ToTable("GRUPO");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.IdCurso).HasColumnName("Id_Curso");

                entity.HasOne(d => d.IdCursoNavigation)
                    .WithMany(p => p.Grupos)
                    .HasForeignKey(d => d.IdCurso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("GRUPO_FK");
            });

            modelBuilder.Entity<NoticiaDeCurso>(entity =>
            {
                entity.HasKey(e => new { e.IdNoticia, e.IdCurso })
                    .HasName("NOTICIA_DE_CURSO_PK");

                entity.ToTable("NOTICIA_DE_CURSO");

                entity.Property(e => e.IdNoticia).HasColumnName("Id_Noticia");

                entity.Property(e => e.IdCurso).HasColumnName("Id_Curso");

                entity.HasOne(d => d.IdCursoNavigation)
                    .WithMany(p => p.NoticiaDeCursos)
                    .HasForeignKey(d => d.IdCurso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CURSO_DE_NOTICIA_FK");

                entity.HasOne(d => d.IdNoticiaNavigation)
                    .WithMany(p => p.NoticiaDeCursos)
                    .HasForeignKey(d => d.IdNoticia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("NOTICIA_DE_CURSO_FK");
            });

            modelBuilder.Entity<Noticium>(entity =>
            {
                entity.ToTable("NOTICIA");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Fecha).HasColumnType("date");

                entity.Property(e => e.IdUsuario).HasColumnName("Id_Usuario");

                entity.Property(e => e.Mensaje)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Titulo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.AutorNavigation)
                    .WithMany(p => p.Noticia)
                    .HasForeignKey(d => d.Autor)
                    .HasConstraintName("NOTICIA_USUARIO_FK");
            });

            modelBuilder.Entity<PerteneceUsuarioGrupo>(entity =>
            {
                entity.HasKey(e => new { e.IdGrupo, e.IdUsuario })
                    .HasName("PERTENECE_USUARIO_GRUPO_PK");

                entity.ToTable("PERTENECE_USUARIO_GRUPO");

                entity.Property(e => e.IdGrupo).HasColumnName("Id_Grupo");

                entity.Property(e => e.IdUsuario).HasColumnName("Id_Usuario");

                entity.HasOne(d => d.IdGrupoNavigation)
                    .WithMany(p => p.PerteneceUsuarioGrupos)
                    .HasForeignKey(d => d.IdGrupo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PERTENECE_USUARIO_GRUPO_CURSO_FK");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.PerteneceUsuarioGrupos)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PERTENECE_USUARIO_GRUPO_USUARIO_FK");
            });

            modelBuilder.Entity<Rol>(entity =>
            {
                entity.ToTable("ROL");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Rubro>(entity =>
            {
                entity.ToTable("RUBRO");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.IdElemento).HasColumnName("Id_Elemento");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Porcentaje).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<Semestre>(entity =>
            {
                entity.ToTable("SEMESTRE");

                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<Tipo>(entity =>
            {
                entity.ToTable("TIPO");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Nombre)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("USUARIO");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.IdRol).HasColumnName("Id_Rol");

                entity.HasOne(d => d.IdRolNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdRol)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("USUARIO_FK");
            });

            modelBuilder.Entity<UsuarioAdministraRubro>(entity =>
            {
                entity.HasKey(e => new { e.IdRubro, e.IdUsuario })
                    .HasName("USUARIO_ADMINISTRA_RUBRO_PK");

                entity.ToTable("USUARIO_ADMINISTRA_RUBRO");

                entity.Property(e => e.IdRubro).HasColumnName("Id_Rubro");

                entity.Property(e => e.IdUsuario).HasColumnName("Id_Usuario");

                entity.HasOne(d => d.IdRubroNavigation)
                    .WithMany(p => p.UsuarioAdministraRubros)
                    .HasForeignKey(d => d.IdRubro)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("USUARIO_ADMINISTRA_RUBRO_RUBRO_FK");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.UsuarioAdministraRubros)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("USUARIO_ADMINISTRA_RUBRO_USUARIO_FK");
            });

            modelBuilder.Entity<UsuarioAsignaEvaluacion>(entity =>
            {
                entity.HasKey(e => new { e.IdUsuario, e.IdEvaluacion })
                    .HasName("USUARIO_ASIGNA_EVALUACION_PK");

                entity.ToTable("USUARIO_ASIGNA_EVALUACION");

                entity.Property(e => e.IdUsuario).HasColumnName("Id_Usuario");

                entity.Property(e => e.IdEvaluacion).HasColumnName("Id_Evaluacion");

                entity.HasOne(d => d.IdEvaluacionNavigation)
                    .WithMany(p => p.UsuarioAsignaEvaluacions)
                    .HasForeignKey(d => d.IdEvaluacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("USUARIO_ASIGNA_EVALUACION_EVALUACION_FK");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.UsuarioAsignaEvaluacions)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("USUARIO_ASIGNA_EVALUACION_USUARIO_FK");
            });

            modelBuilder.Entity<UsuarioCreaElemento>(entity =>
            {
                entity.HasKey(e => new { e.IdUsuario, e.IdElemento })
                    .HasName("USUARIO_CREA_ELEMENTO_PK");

                entity.ToTable("USUARIO_CREA_ELEMENTO");

                entity.Property(e => e.IdUsuario).HasColumnName("Id_Usuario");

                entity.Property(e => e.IdElemento).HasColumnName("Id_Elemento");

                entity.HasOne(d => d.IdElementoNavigation)
                    .WithMany(p => p.UsuarioCreaElementos)
                    .HasForeignKey(d => d.IdElemento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ELEMENTO_CREA_USUARIO_FK");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.UsuarioCreaElementos)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("USUARIO_CREA_ELEMENTO_FK");
            });

            modelBuilder.Entity<UsuarioSubeEntregable>(entity =>
            {
                entity.HasKey(e => new { e.IdUsuario, e.IdEntregable })
                    .HasName("USUARIO_SUBE_ENTREGABLE_PK");

                entity.ToTable("USUARIO_SUBE_ENTREGABLE");

                entity.Property(e => e.IdUsuario).HasColumnName("Id_Usuario");

                entity.Property(e => e.IdEntregable).HasColumnName("Id_Entregable");

                entity.HasOne(d => d.IdEntregableNavigation)
                    .WithMany(p => p.UsuarioSubeEntregables)
                    .HasForeignKey(d => d.IdEntregable)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ENTREGABLE_SUBE_USUARIO_FK");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.UsuarioSubeEntregables)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("USUARIO_SUBE_ENTREGABLE_FK");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
