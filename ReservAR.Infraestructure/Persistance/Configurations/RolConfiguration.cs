using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReservAR.Domain.RolAggregate;
using ReservAR.Domain.RolAggregate.ValueObjects;

namespace ReservAR.Infraestructure.Persistance.Configurations;

public sealed class RolConfiguration : IEntityTypeConfiguration<Rol>
{
    public void Configure(EntityTypeBuilder<Rol> builder)
    {
        ConfigureRol(builder);
    }

    public static void ConfigureRol(EntityTypeBuilder<Rol> builder)
    {
        builder.ToTable("Roles");

        builder.HasKey(r => r.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => RolId.Create(value));

        builder.Property(r => r.Descripcion)
            .IsRequired()
            .HasMaxLength(15);
    }
}
