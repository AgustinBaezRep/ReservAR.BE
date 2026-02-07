using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReservAR.Domain.AtributoAggregate;
using ReservAR.Domain.AtributoAggregate.ValueObjects;


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


    }
}
