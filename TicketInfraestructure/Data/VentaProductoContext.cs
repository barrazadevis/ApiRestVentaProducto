using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace RegistroInfraestructure.Data
{
    public partial class VentaProductoContext : DbContext
    {
        public VentaProductoContext()
        {
        }

        public VentaProductoContext(DbContextOptions<VentaProductoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Producto> Producto { get; set; }
        public virtual DbSet<Venta> Venta { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.IdCliente)
                    .HasName("PK__Cliente__D5946642A2CD64DB");

                entity.Property(e => e.Apellido)
                    .HasMaxLength(70)
                    .IsUnicode(false);

                entity.Property(e => e.Cedula)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.IdProducto)
                    .HasName("PK__Producto__09889210E4D82B35");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(70)
                    .IsUnicode(false);

                entity.Property(e => e.ValorUnitario).HasColumnType("decimal(15, 2)");
            });

            modelBuilder.Entity<Venta>(entity =>
            {
                entity.HasKey(e => e.IdVenta)
                    .HasName("PK__Venta__BC1240BD94FDA71B");

                entity.Property(e => e.Cantidad);

                entity.Property(e => e.ValorTotal).HasColumnType("decimal(15, 2)");

                entity.Property(e => e.ValorUnitario).HasColumnType("decimal(15, 2)");

                entity.Property(e => e.IdProducto);

                entity.Property(e => e.IdCliente);

            });

        }

    }
}
