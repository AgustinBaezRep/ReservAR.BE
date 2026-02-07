using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using ReservAR.Domain.ServicioAggregate;
using ReservAR.Domain.ServicioAggregate.ValueObjects;

namespace ReservAR.Infraestructure.Persistance.Configurations;

public sealed class ServicioConfiguration : IEntityTypeConfiguration<Servicio>
{
    public void Configure(EntityTypeBuilder<Servicio> builder)
    {
        ConfigureServicio(builder);
    }

    public static void ConfigureServicio(EntityTypeBuilder<Servicio> builder)
    {
        builder.ToTable("Servicios");

        builder.HasKey(s => s.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => ServicioId.Create(value));

        builder.Property(s => s.Activo)
            .HasDefaultValue(false);


    }
}
