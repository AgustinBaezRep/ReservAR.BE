using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReservAR.Domain.ComplejoAggregate.ValueObjects;
using ReservAR.Domain.RolAggregate.ValueObjects;
using ReservAR.Domain.UserAggregate;
using ReservAR.Domain.UserAggregate.ValueObjects;

namespace ReservAR.Infraestructure.Persistance.Configurations;

public sealed class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
{
    public void Configure(EntityTypeBuilder<Usuario> builder)
    {
        ConfigureUsuario(builder);
    }

    public static void ConfigureUsuario(EntityTypeBuilder<Usuario> builder)
    {
        builder.ToTable("Usuarios");

        builder.HasKey(u => u.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => UsuarioId.Create(value));

        builder.HasOne(u => u.Rol)
            .WithMany()
            .HasForeignKey(u => u.IdRol)
            .IsRequired()
            .OnDelete(DeleteBehavior.NoAction);

        builder.Property(x => x.IdRol)
            .HasConversion(
                id => id.Value,
                value => RolId.Create(value));

        builder.HasOne(u => u.Complejo)
            .WithMany(c => c.Usuarios)
            .HasForeignKey(u => u.IdComplejo)
            .IsRequired()
            .OnDelete(DeleteBehavior.NoAction);

        builder.Property(x => x.IdComplejo)
            .HasConversion(
                id => id.Value,
                value => ComplejoId.Create(value));
    }
}
