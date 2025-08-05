using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReservAR.Domain.CanchaAggregate;
using ReservAR.Domain.CanchaAggregate.ValueObjects;
using ReservAR.Domain.ComplejoAggregate.ValueObjects;
using ReservAR.Domain.DeporteAggregate.ValueObjects;
using ReservAR.Domain.PisoAggregate.ValueObjects;

namespace ReservAR.Infraestructure.Persistance.Configurations;

public sealed class CanchaConfiguration : IEntityTypeConfiguration<Cancha>
{
    public void Configure(EntityTypeBuilder<Cancha> builder)
    {
        ConfigureCancha(builder);
    }

    public static void ConfigureCancha(EntityTypeBuilder<Cancha> builder)
    {
        builder.ToTable("Canchas");

        builder.HasKey(c => c.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => CanchaId.Create(value));

        builder.Property(c => c.Nombre)
            .HasMaxLength(25);

        builder.Property(c => c.Activa)
            .HasDefaultValue(true);

        builder.Property(c => c.Seña)
            .IsRequired(false);

        builder.HasOne(c => c.Deporte)
            .WithMany(c => c.Canchas)
            .HasForeignKey(c => c.IdDeporte)
            .IsRequired()
            .OnDelete(DeleteBehavior.NoAction);

        builder.Property(x => x.IdDeporte)
            .HasConversion(
                id => id.Value,
                value => DeporteId.Create(value));

        builder.HasOne(c => c.Complejo)
            .WithMany(c => c.Canchas)
            .HasForeignKey(c => c.IdComplejo)
            .IsRequired()
            .OnDelete(DeleteBehavior.NoAction);

        builder.Property(x => x.IdComplejo)
            .HasConversion(
                id => id.Value,
                value => ComplejoId.Create(value));

        builder.HasOne(c => c.TipoPiso)
            .WithMany(c => c.Canchas)
            .HasForeignKey(c => c.IdTipoPiso)
            .OnDelete(DeleteBehavior.NoAction);

        builder.Property(x => x.IdTipoPiso)
            .HasConversion(
                id => id.Value,
                value => PisoId.Create(value));
    }
}
