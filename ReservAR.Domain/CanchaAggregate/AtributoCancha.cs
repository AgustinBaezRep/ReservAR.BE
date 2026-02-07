using ReservAR.Domain.AtributoAggregate;
using ReservAR.Domain.AtributoAggregate.ValueObjects;
using ReservAR.Domain.CanchaAggregate.ValueObjects;
using ReservAR.Domain.Common.Models;

namespace ReservAR.Domain.CanchaAggregate;

public sealed class AtributoCancha : EntityBase<AtributoCanchaId>
{
    public CanchaId IdCancha { get; private set; }
    public Cancha Cancha { get; }
    public AtributoId IdAtributo { get; private set; }
    public Atributo Atributo { get; }

    public AtributoCancha() { }

    internal AtributoCancha(CanchaId idCancha, AtributoId idAtributo)
    {
        Id = AtributoCanchaId.CreateUnique();
        IdCancha = idCancha;
        IdAtributo = idAtributo;
    }
}
