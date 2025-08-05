using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReservAR.Domain.ComplejoAggregate.ValueObjects;
using ReservAR.Domain.ProductoAggregate;
using ReservAR.Domain.ProductoAggregate.ValueObjects;

namespace ReservAR.Infraestructure.Persistance.Configurations;

public sealed class ProductoConfiguration : IEntityTypeConfiguration<Producto>
{
    public void Configure(EntityTypeBuilder<Producto> builder)
    {
        ConfigureProducto(builder);
    }

    public static void ConfigureProducto(EntityTypeBuilder<Producto> builder)
    {
        builder.ToTable("Productos");

        builder.HasKey(p => p.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => ProductoId.Create(value));

        builder.Property(p => p.PrecioCompra)
            .IsRequired(false)
            .HasPrecision(18, 2);

        builder.Property(p => p.PrecioVenta)
            .IsRequired()
            .HasPrecision(18, 2);

        builder.HasOne(p => p.Complejo)
            .WithMany(p => p.Productos)
            .HasForeignKey(p => p.IdComplejo)
            .IsRequired()
            .OnDelete(DeleteBehavior.NoAction);

        builder.Property(x => x.IdComplejo)
            .HasConversion(
                id => id.Value,
                value => ComplejoId.Create(value));
    }
}
