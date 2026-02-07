using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReservAR.Domain.ComplejoAggregate;
using ReservAR.Domain.ComplejoAggregate.ValueObjects;
using ReservAR.Domain.ServicioAggregate.ValueObjects;

namespace ReservAR.Infraestructure.Persistance.Configurations;

public sealed class ServicioComplejoConfiguration : IEntityTypeConfiguration<ServicioComplejo>
{
    public void Configure(EntityTypeBuilder<ServicioComplejo> builder)
    {
        ConfigureServicioComplejo(builder);
    }

    public static void ConfigureServicioComplejo(EntityTypeBuilder<ServicioComplejo> builder)
    {
        builder.ToTable("ServiciosComplejo");

        builder.HasKey(sc => sc.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => ServicioComplejoId.Create(value));

        builder.HasOne(sc => sc.Complejo)
            .WithMany(c => c.Servicios)
            .HasForeignKey(sc => sc.IdComplejo)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

        builder.Property(x => x.IdComplejo)
            .HasConversion(
                id => id.Value,
                value => ComplejoId.Create(value));

        builder.HasOne(sc => sc.Servicio)
            .WithMany()
            .HasForeignKey(sc => sc.IdServicio)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

        builder.Property(x => x.IdServicio)
            .HasConversion(
                id => id.Value,
                value => ServicioId.Create(value));
    }
}
