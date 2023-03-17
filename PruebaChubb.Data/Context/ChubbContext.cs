using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PruebaChubb.Data.Context
{
    public partial class ChubbContext : DbContext
    {
        public ChubbContext()
        {
        }

        public ChubbContext(DbContextOptions<ChubbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Apuestum> Apuesta { get; set; } = null!;
        public virtual DbSet<DetalleApuestum> DetalleApuesta { get; set; } = null!;
        public virtual DbSet<Ruletum> Ruleta { get; set; } = null!;
        public virtual DbSet<TipoApuestum> TipoApuesta { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=LAPTOP-HTKKQHGE;Initial Catalog=PruebaChubb;Persist Security Info=True;User ID=sa;Password=sa123456; TrustServerCertificate=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Apuestum>(entity =>
            {
                entity.HasOne(d => d.IdRuletaNavigation)
                    .WithMany(p => p.Apuesta)
                    .HasForeignKey(d => d.IdRuleta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Apuesta_ruleta1");
            });

            modelBuilder.Entity<DetalleApuestum>(entity =>
            {
                entity.HasOne(d => d.IdApuestaNavigation)
                    .WithMany(p => p.DetalleApuesta)
                    .HasForeignKey(d => d.IdApuesta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DetalleApuesta_Apuesta");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.DetalleApuesta)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DetalleApuesta_Usuario");

                entity.HasOne(d => d.TipoNavigation)
                    .WithMany(p => p.DetalleApuesta)
                    .HasForeignKey(d => d.Tipo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DetalleApuesta_TipoApuesta");
            });

            modelBuilder.Entity<Ruletum>(entity =>
            {
                entity.HasKey(e => e.IdRuleta)
                    .HasName("PK_ruleta");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
