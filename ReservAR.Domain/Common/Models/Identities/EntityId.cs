namespace ReservAR.Domain.Common.Models.Identities
{
    public abstract class EntityId : ValueObject
    {
        public Guid Value { get; protected set; }

        protected EntityId() { }

        protected EntityId(Guid value)
        {
            Value = value;
        }

        public override IEnumerable<object?> GetEqualityComponents()
        {
            yield return Value;
        }

        public override string? ToString() => Value.ToString() ?? base.ToString();
    }
}
