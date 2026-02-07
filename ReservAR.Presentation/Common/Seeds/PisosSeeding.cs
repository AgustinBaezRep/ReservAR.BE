using ReservAR.Domain.PisoAggregate;
using ReservAR.Domain.PisoAggregate.Enums;
using ReservAR.Domain.PisoAggregate.ValueObjects;
using ReservAR.Infraestructure.Persistance;

namespace ReservAR.Presentation.Common.Seeds;

public static class PisosSeeding
{
    public static void Seed(ReservarDbContext context)
    {
        if (!context.Pisos.Any())
        {
            var pisos = new List<Piso>();

            foreach (TipoPiso tipoPiso in Enum.GetValues(typeof(TipoPiso)))
            {
                var piso = new Piso();
                typeof(Piso).GetProperty("Id")!.SetValue(piso, PisoId.CreateUnique());
                typeof(Piso).GetProperty("Descripcion")!.SetValue(piso, tipoPiso);
                pisos.Add(piso);
            }

            context.Pisos.AddRange(pisos);
            context.SaveChanges();
        }
    }
}
