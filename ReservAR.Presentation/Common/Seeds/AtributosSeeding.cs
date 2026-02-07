using ReservAR.Domain.AtributoAggregate;
using ReservAR.Domain.AtributoAggregate.ValueObjects;
using ReservAR.Infraestructure.Persistance;

namespace ReservAR.Presentation.Common.Seeds;

public static class AtributosSeeding
{
    public static void Seed(ReservarDbContext context)
    {
        if (!context.Atributos.Any())
        {
            var atributos = new List<Atributo>();

            var nombresAtributos = new[]
            {
                "Techado",
                "Iluminación",
                "Tribunas"
            };

            foreach (var nombre in nombresAtributos)
            {
                var atributo = new Atributo();
                typeof(Atributo).GetProperty("Id")!.SetValue(atributo, AtributoId.CreateUnique());
                typeof(Atributo).GetProperty("Nombre")!.SetValue(atributo, nombre);
                typeof(Atributo).GetProperty("Activo")!.SetValue(atributo, true);
                atributos.Add(atributo);
            }

            context.Atributos.AddRange(atributos);
            context.SaveChanges();
        }
    }
}
