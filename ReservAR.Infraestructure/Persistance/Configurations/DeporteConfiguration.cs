using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReservAR.Domain.DeporteAggregate;
using ReservAR.Domain.DeporteAggregate.ValueObjects;

namespace ReservAR.Infraestructure.Persistance.Configurations;

public sealed class DeporteConfiguration : IEntityTypeConfiguration<Deporte>
{
    public void Configure(EntityTypeBuilder<Deporte> builder)
    {
        ConfigureDeporte(builder);
    }

    public static void ConfigureDeporte(EntityTypeBuilder<Deporte> builder)
    {
        builder.ToTable("Deportes");

        builder.HasKey(d => d.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => DeporteId.Create(value));

        builder.Property(d => d.Nombre)
            .IsRequired()
            .HasMaxLength(25);
    }
}
