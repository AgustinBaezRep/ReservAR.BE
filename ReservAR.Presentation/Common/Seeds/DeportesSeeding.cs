using ReservAR.Domain.DeporteAggregate;
using ReservAR.Domain.DeporteAggregate.ValueObjects;
using ReservAR.Infraestructure.Persistance;

namespace ReservAR.Presentation.Common.Seeds;

public static class DeportesSeeding
{
    public static void Seed(ReservarDbContext context)
    {
        if (!context.Deportes.Any())
        {
            var deportes = new List<Deporte>();

            var nombresDeportes = new[]
            {
                "Fútbol 5",
                "Fútbol 7",
                "Fútbol 11",
                "Tenis",
                "Pádel",
                "Básquet",
                "Voleibol"
            };

            foreach (var nombre in nombresDeportes)
            {
                var deporte = new Deporte();
                typeof(Deporte).GetProperty("Id")!.SetValue(deporte, DeporteId.CreateUnique());
                typeof(Deporte).GetProperty("Nombre")!.SetValue(deporte, nombre);
                deportes.Add(deporte);
            }

            context.Deportes.AddRange(deportes);
            context.SaveChanges();
        }
    }
}
