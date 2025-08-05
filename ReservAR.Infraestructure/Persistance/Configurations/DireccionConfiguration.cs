using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReservAR.Domain.DireccionAggregate;
using ReservAR.Domain.DireccionAggregate.ValueObjects;

namespace ReservAR.Infraestructure.Persistance.Configurations;

public sealed class DireccionConfiguration : IEntityTypeConfiguration<Direccion>
{
    public void Configure(EntityTypeBuilder<Direccion> builder)
    {
        ConfigureDireccion(builder);
    }

    public static void ConfigureDireccion(EntityTypeBuilder<Direccion> builder)
    {
        builder.ToTable("Direcciones");

        builder.HasKey(d => d.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => DireccionId.Create(value));

        builder.Property(d => d.CoordenadaX)
            .IsRequired(false)
            .HasMaxLength(50);

        builder.Property(d => d.CoordenadaY)
            .IsRequired(false)
            .HasMaxLength(50);
    }
}
