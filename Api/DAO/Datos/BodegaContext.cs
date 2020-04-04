using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DAO.Datos
{
    public partial class BodegaContext : DbContext
    {
        public BodegaContext()
        {
        }

        public BodegaContext(DbContextOptions<BodegaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Bodegas> Bodegas { get; set; }
        public virtual DbSet<Categoria> Categoria { get; set; }
        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Producto> Producto { get; set; }
        public virtual DbSet<ServicioAlojamiento> ServicioAlojamiento { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("");
//            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bodegas>(entity =>
            {
                entity.HasKey(e => e.IdBodega)
                    .HasName("PK_Bodega");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.HasKey(e => e.IdCategoria);

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdBodegaNavigation)
                    .WithMany(p => p.Categoria)
                    .HasForeignKey(d => d.IdBodega)
                    .HasConstraintName("FK_Categoria_Bodega");
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.IdCliente);

                entity.Property(e => e.Apellidos)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Cedula)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nombres)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.IdProducto);

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FechaExpiracion).HasColumnType("datetime");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdCategoriaNavigation)
                    .WithMany(p => p.Producto)
                    .HasForeignKey(d => d.IdCategoria)
                    .HasConstraintName("FK_Producto_Categoria");
            });

            modelBuilder.Entity<ServicioAlojamiento>(entity =>
            {
                entity.HasKey(e => e.IdServicio);

                entity.Property(e => e.NombreServicio)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdBodegaNavigation)
                    .WithMany(p => p.ServicioAlojamiento)
                    .HasForeignKey(d => d.IdBodega)
                    .HasConstraintName("FK_ServicioAlojamiento_Bodega");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.ServicioAlojamiento)
                    .HasForeignKey(d => d.IdCliente)
                    .HasConstraintName("FK_ServicioAlojamiento_Cliente");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
