using ReservAR.Domain.ComplejoAggregate;
using ReservAR.Domain.ComplejoAggregate.ValueObjects;
using ReservAR.Infraestructure.Persistance;

namespace ReservAR.Presentation.Common.Seeds;

public static class ComplejosSeeding
{
    public static readonly ComplejoId DefaultComplejoId = ComplejoId.CreateUnique();

    public static void Seed(ReservarDbContext context)
    {
        if (!context.Complejos.Any())
        {
            var complejo = new Complejo();
            typeof(Complejo).GetProperty("Id")!.SetValue(complejo, DefaultComplejoId);
            typeof(Complejo).GetProperty("Nombre")!.SetValue(complejo, "Complejo Demo");
            typeof(Complejo).GetProperty("Telefono")!.SetValue(complejo, 1155551234L);
            typeof(Complejo).GetProperty("Online")!.SetValue(complejo, true);

            context.Complejos.Add(complejo);
            context.SaveChanges();
        }
    }
}
