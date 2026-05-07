namespace api.Helpers;

public class PagedResult<T>(int pageNumber, int pageSize, int Items, IReadOnlyList<T> data) where T : class
{
    public int PageNumber { get; set; } = pageNumber;
    public int PageSize { get; set; } = pageSize;
    public int Items { get; set; } = Items;
    public IReadOnlyList<T> Data { get; set; } = data;
}

