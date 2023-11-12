namespace HRIS.Domain.Models.Common
{
    public class FilterWithPagination : Pagination
    {
        public string? Filter { get; set; }
        public string? Value { get; set; }
    }
}
