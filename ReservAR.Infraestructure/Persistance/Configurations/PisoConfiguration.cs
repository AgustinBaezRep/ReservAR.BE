using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReservAR.Domain.PisoAggregate;
using ReservAR.Domain.PisoAggregate.Enums;
using ReservAR.Domain.PisoAggregate.ValueObjects;

namespace ReservAR.Infraestructure.Persistance.Configurations;

public sealed class PisoConfiguration : IEntityTypeConfiguration<Piso>
{
    public void Configure(EntityTypeBuilder<Piso> builder)
    {
        ConfigurePiso(builder);
    }

    public static void ConfigurePiso(EntityTypeBuilder<Piso> builder)
    {
        builder.ToTable("Pisos");

        builder.HasKey(p => p.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => PisoId.Create(value));

        builder.Property(p => p.Descripcion)
            .IsRequired()
            .HasConversion(
                tipo => tipo.ToString(),
                tipoString => (TipoPiso)Enum.Parse(typeof(TipoPiso), tipoString));
    }
}
