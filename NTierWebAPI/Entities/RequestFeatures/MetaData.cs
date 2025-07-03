
namespace Entities.RequestFeatures 
{ 
    public class MetaData
    {
        public int CurrentPage { get; set; }
        public int TotalPage { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public int OffSet => (CurrentPage - 1) * PageSize;

        public bool HasPreviousPage => CurrentPage > 1; 
        public bool HasAfterwardsPage => CurrentPage < TotalPage;
    }
}
