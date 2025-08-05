using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReservAR.Domain.ComplejoAggregate.ValueObjects;
using ReservAR.Domain.ConsumoConfiguration;
using ReservAR.Domain.ConsumoConfiguration.ValueObjects;
using ReservAR.Domain.ReservaAggregate.ValueObjects;

namespace ReservAR.Infraestructure.Persistance.Configurations;

public sealed class ConsumoConfiguration : IEntityTypeConfiguration<Consumo>
{
    public void Configure(EntityTypeBuilder<Consumo> builder)
    {
        ConfigureConsumo(builder);
    }

    public static void ConfigureConsumo(EntityTypeBuilder<Consumo> builder)
    {
        builder.ToTable("Consumos");

        builder.HasKey(c => c.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => ConsumoId.Create(value));

        builder.Property(c => c.Concepto)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(c => c.Cantidad)
            .IsRequired(false);

        builder.HasOne(c => c.Reserva)
            .WithMany()
            .HasForeignKey(c => c.IdReserva)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.NoAction);

        builder.Property(x => x.IdReserva)
            .HasConversion(
                id => id.Value,
                value => ReservaId.Create(value));

        builder.HasOne(c => c.Complejo)
            .WithMany(c => c.Consumos)
            .HasForeignKey(c => c.IdComplejo)
            .IsRequired()
            .OnDelete(DeleteBehavior.NoAction);

        builder.Property(x => x.IdComplejo)
            .HasConversion(
                id => id.Value,
                value => ComplejoId.Create(value));
    }
}
