using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReservAR.Domain.ConsumoAggregate.ValueObjects;
using ReservAR.Domain.ProductoAggregate.ValueObjects;
using ReservAR.Domain.ProductoConsumoAggregate;
using ReservAR.Domain.ProductoConsumoAggregate.ValueObjects;

namespace ReservAR.Infraestructure.Persistance.Configurations;

public sealed class ProductoConsumoConfiguration : IEntityTypeConfiguration<ProductoConsumo>
{
    public void Configure(EntityTypeBuilder<ProductoConsumo> builder)
    {
        ConfigureProductoConsumo(builder);
    }

    public static void ConfigureProductoConsumo(EntityTypeBuilder<ProductoConsumo> builder)
    {
        builder.ToTable("ProductosConsumo");

        builder.HasKey(pc => pc.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => ProductoConsumoId.Create(value));

        builder.HasOne(pc => pc.Producto)
            .WithMany(p => p.ProductosConsumo)
            .HasForeignKey(pc => pc.IdProducto)
            .IsRequired()
            .OnDelete(DeleteBehavior.NoAction);

        builder.Property(x => x.IdProducto)
            .HasConversion(
                id => id.Value,
                value => ProductoId.Create(value));

        builder.HasOne(pc => pc.Consumo)
            .WithMany(c => c.ProductosConsumo)
            .HasForeignKey(pc => pc.IdConsumo)
            .IsRequired()
            .OnDelete(DeleteBehavior.NoAction);

        builder.Property(x => x.IdConsumo)
            .HasConversion(
                id => id.Value,
                value => ConsumoId.Create(value));
    }
}
