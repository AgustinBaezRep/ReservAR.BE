namespace ReservAR.Contracts.Common;

public record PaginationCriteria
{
    public string? SearchText { get; set; }
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public bool MustReturnAll { get; set; }

    public PaginationCriteria()
        : this(string.Empty, 1, 10, false)
    {
    }

    public PaginationCriteria(string? searchText, int pageNumber, int pageSize, bool mustReturnAll)
    {
        SearchText = searchText;
        PageNumber = pageNumber;
        PageSize = pageSize;
        MustReturnAll = mustReturnAll;
    }
}
