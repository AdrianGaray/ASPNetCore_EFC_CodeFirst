using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNet_Core_EF_CodeFirst.Models
{
    public class DbContexto : DbContext
    {
        public DbContexto()
        {

        }

        // :base, indicamos el parametro al padre DbContext de la que hereda esta clase.
        public DbContexto(DbContextOptions<DbContexto> options): base(options)
        {

        }

        //Declaramos las propiedades para exponer el modelo
        public virtual DbSet<Categoria> Categoria { get; set; }
        public virtual DbSet<Producto> Producto { get; set; }

        // mapear nuestras Entidades con la base de datos 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.ToTable("categoria");
                // indica la clave primaria
                entity.HasKey(e => e.idcategoria);
                entity.Property(e => e.idcategoria).HasColumnName("idcategoria");

                entity.Property(e => e.nombre)
                    // indica que es un campo requerido
                    .IsRequired()
                    .HasColumnName("nombre")
                    // indica una maximo de 50 caracteres
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.descripcion)
                    .HasColumnName("descripcion")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.estado)
                    .HasColumnName("estado")
                    // indica que por defecto tenga el valor en 1.
                    .HasDefaultValueSql("((1))");
            });
            modelBuilder.Entity<Producto>(entity =>
            {
                entity.ToTable("producto");
                entity.HasKey(e => e.idproducto);
                entity.Property(e => e.idproducto).HasColumnName("idproducto");

                entity.Property(e => e.idcategoria).HasColumnName("idcategoria");

                entity.Property(e => e.codigo)
                    .HasColumnName("codigo")
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.HasIndex(e => e.nombre)
                    .IsUnique();

                entity.Property(e => e.precio_venta)
                    .IsRequired()
                    .HasColumnName("precio_venta")
                    .HasColumnType("decimal(11, 2)");

                entity.Property(e => e.stock)
                    .IsRequired()
                    .HasColumnName("stock");

                entity.Property(e => e.descripcion)
                    .HasColumnName("descripcion")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.estado)
                    .HasColumnName("estado")
                    .HasDefaultValueSql("((1))");

                entity.HasOne(d => d.Categoria)
                    .WithMany(p => p.Producto)
                    .HasForeignKey(d => d.idcategoria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_producto_categoria");
            });
        }
    }
}
