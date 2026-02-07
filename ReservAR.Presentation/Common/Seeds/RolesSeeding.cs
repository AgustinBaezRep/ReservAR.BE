using ReservAR.Domain.RolAggregate;
using ReservAR.Domain.RolAggregate.ValueObjects;
using ReservAR.Infraestructure.Persistance;

namespace ReservAR.Presentation.Common.Seeds;

public static class RolesSeeding
{
    public static readonly RolId AdminRolId = RolId.CreateUnique();
    public static readonly RolId UsuarioRolId = RolId.CreateUnique();

    public static void Seed(ReservarDbContext context)
    {
        if (!context.Roles.Any())
        {
            var roles = new List<Rol>();

            var adminRol = new Rol();
            typeof(Rol).GetProperty("Id")!.SetValue(adminRol, AdminRolId);
            typeof(Rol).GetProperty("Descripcion")!.SetValue(adminRol, "Admin");
            roles.Add(adminRol);

            var usuarioRol = new Rol();
            typeof(Rol).GetProperty("Id")!.SetValue(usuarioRol, UsuarioRolId);
            typeof(Rol).GetProperty("Descripcion")!.SetValue(usuarioRol, "Usuario");
            roles.Add(usuarioRol);

            context.Roles.AddRange(roles);
            context.SaveChanges();
        }
    }
}
