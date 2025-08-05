using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReservAR.Domain.ComplejoAggregate.ValueObjects;
using ReservAR.Domain.DisponibilidadHorariaAggregate;
using ReservAR.Domain.DisponibilidadHorariaAggregate.ValueObjects;

namespace ReservAR.Infraestructure.Persistance.Configurations;

public sealed class DisponibilidadHorariaConfiguration : IEntityTypeConfiguration<DisponibilidadHoraria>
{
    public void Configure(EntityTypeBuilder<DisponibilidadHoraria> builder)
    {
        ConfigureDisponibilidadHoraria(builder);
    }

    public static void ConfigureDisponibilidadHoraria(EntityTypeBuilder<DisponibilidadHoraria> builder)
    {
        builder.ToTable("DisponibilidadesHorarias");

        builder.HasKey(dh => dh.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => DisponibilidadHorariaId.Create(value));

        builder.Property(dh => dh.Activo)
            .HasDefaultValue(false);

        builder.Property(dh => dh.HoraDesde)
            .IsRequired();

        builder.Property(dh => dh.HoraHasta)
            .IsRequired();

        builder.HasOne(dh => dh.Complejo)
            .WithMany(c => c.DisponibilidadesHorarias)
            .HasForeignKey(dh => dh.IdComplejo)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.NoAction);

        builder.Property(x => x.IdComplejo)
            .HasConversion(
                id => id.Value,
                value => ComplejoId.Create(value));
    }
}
