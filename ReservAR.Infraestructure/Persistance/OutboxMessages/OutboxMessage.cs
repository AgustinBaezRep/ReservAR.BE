namespace ReservAR.Infraestructure.Persistance.OutboxMessages;

public sealed class OutboxMessage
{
    public Guid Id { get; set; }
    public string Type { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public DateTime OccurredOnDateTime { get; set; }
    public DateTime? ProcessedOnDateTime { get; set; }
    public string? Error { get; set; }
}
