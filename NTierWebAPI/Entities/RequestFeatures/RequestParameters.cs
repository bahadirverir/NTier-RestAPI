
namespace Entities.RequestFeatures 
{
    public abstract class RequestParameters
    {
        public int PageNumber { get; set; } = 1; 

        private int _pageSize = 10; 

        protected virtual int MaxPageSize => 10;

        public int PageSize
        {
            get { return _pageSize; }
            set { _pageSize = value > MaxPageSize ? MaxPageSize : value; }
        }

        public String? OrderBy { get; set; }
        public String? Fields { get; set; }
    }
}
