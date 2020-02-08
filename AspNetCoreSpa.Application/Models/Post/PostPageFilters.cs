namespace AspNetCoreSpa.Application.Models.Post
{
    public class PostPageFilters
    {
        public int PageNumber { get; set; }
        public int ItemsPerPage { get; set; }
        
        // public PostSorting Sorting { get; set; }
        // public IEnumerable<PageFilter> Filters { get; set; }
    }
}