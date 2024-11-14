namespace ReservAR.Contracts.Common;

public class PagedResponse<T>
{
    public int CurrentPage { get; private set; } = 1;
    public int TotalPages { get; private set; } = 1;
    public int PageSize { get; private set; } = 50;
    public int TotalCount { get; private set; }
    public bool HasPrevious => CurrentPage > 1;
    public bool HasNext => CurrentPage < TotalPages;
    public List<T> Items { get; private set; }

    public PagedResponse() => Items = [];

    public static PagedResponse<T> ToPagedList(List<T> source, int pageNumber, int pageSize, bool mustReturnAll)
    {
        var response = new PagedResponse<T>
        {
            TotalCount = source.Count,
            PageSize = mustReturnAll ? source.Count : pageSize
        };

        if (mustReturnAll)
        {
            response.TotalPages = 1;
            response.CurrentPage = 1;
            response.Items = source;
        }
        else
        {
            response.TotalPages = (int)Math.Ceiling(response.TotalCount / (double)response.PageSize);
            response.CurrentPage = (response.TotalPages < pageNumber) ? response.TotalPages : (pageNumber < 0) ? 1 : pageNumber;
            response.Items = source.Skip((response.CurrentPage - 1) * response.PageSize).Take(response.PageSize).ToList();
        }

        return response;
    }
}