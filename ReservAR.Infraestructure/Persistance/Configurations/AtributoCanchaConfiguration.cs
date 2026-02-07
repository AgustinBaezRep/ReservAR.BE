using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReservAR.Domain.AtributoAggregate.ValueObjects;
using ReservAR.Domain.CanchaAggregate;
using ReservAR.Domain.CanchaAggregate.ValueObjects;

namespace ReservAR.Infraestructure.Persistance.Configurations;

public sealed class AtributoCanchaConfiguration : IEntityTypeConfiguration<AtributoCancha>
{
    public void Configure(EntityTypeBuilder<AtributoCancha> builder)
    {
        ConfigureAtributoCancha(builder);
    }

    public static void ConfigureAtributoCancha(EntityTypeBuilder<AtributoCancha> builder)
    {
        builder.ToTable("AtributoCanchas");

        builder.HasKey(ac => ac.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => AtributoCanchaId.Create(value));

        builder.HasOne(ac => ac.Cancha)
            .WithMany(c => c.Atributos)
            .HasForeignKey(ac => ac.IdCancha)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

        builder.Property(x => x.IdCancha)
            .HasConversion(
                id => id.Value,
                value => CanchaId.Create(value));

        builder.HasOne(ac => ac.Atributo)
            .WithMany()
            .HasForeignKey(ac => ac.IdAtributo)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

        builder.Property(x => x.IdAtributo)
            .HasConversion(
                id => id.Value,
                value => AtributoId.Create(value));
    }
}
