
namespace Library.Application.Shared
{
    public class PagedList<T> : List<T>
    {
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int PagelSize { get; set; }
        public int TotalCount { get; set; }
        public bool HasPrivious => CurrentPage > 1;
        public bool HasNext => TotalPages > CurrentPage;

        public PagedList(List<T> items, int count, int pageNumber, int pageSize)
        {
            TotalCount = count;
            PagelSize = pageSize;
            CurrentPage = pageNumber;
            TotalPages = (int)Math.Ceiling((double)count / pageSize);
            AddRange(items);    
        }
    }
}
