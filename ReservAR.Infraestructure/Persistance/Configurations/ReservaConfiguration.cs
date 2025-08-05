using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReservAR.Domain.CanchaAggregate.ValueObjects;
using ReservAR.Domain.ReservaAggregate;
using ReservAR.Domain.ReservaAggregate.ValueObjects;
using ReservAR.Domain.UserAggregate.ValueObjects;

namespace ReservAR.Infraestructure.Persistance.Configurations;

public sealed class ReservaConfiguration : IEntityTypeConfiguration<Reserva>
{
    public void Configure(EntityTypeBuilder<Reserva> builder)
    {
        ConfigureReserva(builder);
    }

    public static void ConfigureReserva(EntityTypeBuilder<Reserva> builder)
    {
        builder.ToTable("Reservas");

        builder.HasKey(r => r.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => ReservaId.Create(value));

        builder.Property(r => r.Fijo)
            .HasDefaultValue(false);

        builder.Property(r => r.Pago)
            .HasConversion(
                pago => pago.ToString(),
                pagoString => (TipoPago)Enum.Parse(typeof(TipoPago), pagoString));

        builder.HasOne(r => r.Cancha)
            .WithMany(r => r.Reservas)
            .HasForeignKey(r => r.IdCancha)
            .IsRequired()
            .OnDelete(DeleteBehavior.NoAction);

        builder.Property(x => x.IdCancha)
            .HasConversion(
                id => id.Value,
                value => CanchaId.Create(value));

        builder.HasOne(r => r.Usuario)
            .WithMany(r => r.Reservas)
            .HasForeignKey(r => r.IdUsuario)
            .IsRequired()
            .OnDelete(DeleteBehavior.NoAction);

        builder.Property(x => x.IdUsuario)
            .HasConversion(
                id => id.Value,
                value => UsuarioId.Create(value));
    }
}
