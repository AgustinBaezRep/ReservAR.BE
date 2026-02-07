using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReservAR.Domain.CanchaAggregate.ValueObjects;
using ReservAR.Domain.PrecioAggregate;
using ReservAR.Domain.PrecioAggregate.Enums;
using ReservAR.Domain.PrecioAggregate.ValueObjects;

namespace ReservAR.Infraestructure.Persistance.Configurations;

public sealed class PrecioConfiguration : IEntityTypeConfiguration<Precio>
{
    public void Configure(EntityTypeBuilder<Precio> builder)
    {
        ConfigurePrecio(builder);
    }

    public static void ConfigurePrecio(EntityTypeBuilder<Precio> builder)
    {
        builder.ToTable("Precios");

        builder.HasKey(p => p.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => PrecioId.Create(value));

        builder.Property(p => p.TipoPrecio)
            .HasConversion(
                v => v.ToString(),
                v => (TiposPrecio)Enum.Parse(typeof(TiposPrecio), v));

        builder.HasOne(c => c.Cancha)
            .WithMany(c => c.Precios)
            .HasForeignKey(c => c.IdCancha)
            .IsRequired()
            .OnDelete(DeleteBehavior.NoAction);

        builder.Property(x => x.IdCancha)
            .HasConversion(
                id => id.Value,
                value => CanchaId.Create(value));
    }
}
