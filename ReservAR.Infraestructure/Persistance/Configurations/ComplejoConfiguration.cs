using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReservAR.Domain.ComplejoAggregate;
using ReservAR.Domain.ComplejoAggregate.ValueObjects;
using ReservAR.Domain.DireccionAggregate.ValueObjects;

namespace ReservAR.Infraestructure.Persistance.Configurations;

public sealed class ComplejoConfiguration : IEntityTypeConfiguration<Complejo>
{
    public void Configure(EntityTypeBuilder<Complejo> builder)
    {
        ConfigureComplejo(builder);
    }

    public static void ConfigureComplejo(EntityTypeBuilder<Complejo> builder)
    {
        builder.ToTable("Complejos");

        builder.HasKey(c => c.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => ComplejoId.Create(value));

        builder.Property(c => c.Online)
            .HasDefaultValue(true);

        builder.HasOne(builder => builder.Direccion)
            .WithOne()
            .HasForeignKey<Complejo>("IdDireccion")
            .IsRequired(false)
            .OnDelete(DeleteBehavior.NoAction);

        builder.Property(x => x.IdDireccion)
            .HasConversion(
                id => id.Value,
                value => DireccionId.Create(value));
    }
}
