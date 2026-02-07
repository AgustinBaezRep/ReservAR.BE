using ReservAR.Domain.ServicioAggregate;
using ReservAR.Domain.ServicioAggregate.ValueObjects;
using ReservAR.Infraestructure.Persistance;

namespace ReservAR.Presentation.Common.Seeds;

public static class ServiciosSeeding
{
    public static void Seed(ReservarDbContext context)
    {
        if (!context.Servicios.Any())
        {
            var servicios = new List<Servicio>();

            var descripciones = new[]
            {
                "Estacionamiento",
                "Vestuarios",
                "Wifi",
                "Bar/Cantina"
            };

            foreach (var descripcion in descripciones)
            {
                var servicio = new Servicio();
                typeof(Servicio).GetProperty("Id")!.SetValue(servicio, ServicioId.CreateUnique());
                typeof(Servicio).GetProperty("Descripcion")!.SetValue(servicio, descripcion);
                typeof(Servicio).GetProperty("Activo")!.SetValue(servicio, true);
                servicios.Add(servicio);
            }

            context.Servicios.AddRange(servicios);
            context.SaveChanges();
        }
    }
}
