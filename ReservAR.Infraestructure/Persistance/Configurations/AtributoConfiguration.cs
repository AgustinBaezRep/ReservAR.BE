using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReservAR.Domain.AtributoAggregate;
using ReservAR.Domain.AtributoAggregate.ValueObjects;
using ReservAR.Domain.CanchaAggregate.ValueObjects;

namespace ReservAR.Infraestructure.Persistance.Configurations;

public sealed class AtributoConfiguration : IEntityTypeConfiguration<Atributo>
{
    public void Configure(EntityTypeBuilder<Atributo> builder)
    {
        ConfigureAtributo(builder);
    }

    public static void ConfigureAtributo(EntityTypeBuilder<Atributo> builder)
    {
        builder.ToTable("Atributos");

        builder.HasKey(a => a.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => AtributoId.Create(value));

        builder.Property(a => a.Activo)
            .HasDefaultValue(false);

        builder.HasOne(ac => ac.Cancha)
            .WithMany(c => c.Atributos)
            .HasForeignKey(ac => ac.IdCancha)
            .IsRequired()
            .OnDelete(DeleteBehavior.NoAction);

        builder.Property(x => x.IdCancha)
            .HasConversion(
                id => id.Value,
                value => CanchaId.Create(value));
    }
}
