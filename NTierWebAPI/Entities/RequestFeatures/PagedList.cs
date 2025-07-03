
namespace Entities.RequestFeatures 
{
    public class PagedList<T> : List<T>
    {
        public MetaData MetaData { get; private set; }

        public PagedList(List<T> items, int count, int pageNumber, int pageSize)
        {
            MetaData = new MetaData
            {
                TotalCount = count,
                PageSize = pageSize,
                CurrentPage = pageNumber,
                TotalPage = (int)Math.Ceiling(count / (double)pageSize)
            };
            AddRange(items);
        }

        public static PagedList<T> ToPagedList(IEnumerable<T> source, int pageNumber, int pageSize)
        {
            var count = source.Count();
            var totalPages = (int)Math.Ceiling(count / (double)pageSize);
            
            if(pageNumber > totalPages && totalPages > 0)
                pageNumber = totalPages;
            
            var items = source
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            return new PagedList<T>(items, count, pageNumber, pageSize);
        }

        public static async Task<PagedList<T>> ToPagedListAsync(IQueryable<T> source, int pageNumber, int pageSize)
        {
            var count = await Task.Run(() => source.Count());
            var totalPages = (int)Math.Ceiling(count / (double)pageSize);
            
            if (pageNumber > totalPages && totalPages > 0)
                 pageNumber = totalPages;
            
            var items = await Task.Run(() => source
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList());

            return new PagedList<T>(items, count, pageNumber, pageSize);
        }
    }
}
