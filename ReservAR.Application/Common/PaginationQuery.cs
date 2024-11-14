namespace ReservAR.Application.Common;

public record PaginationQuery
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public bool MustReturnAll { get; set; }
}
