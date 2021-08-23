namespace Domain.Models
{
    public class PagingParam
    {
        public PagingParam(int pageSize,int pageNumber)
        {
            PageSize = pageSize;
            PageNumber = pageNumber;
        }
        const int maxPageSize = 50;
        private int _pageSize = 10;
        public int PageSize
        {
            get => _pageSize;
           private set => _pageSize = (value > maxPageSize) ? maxPageSize : value;
        }
        public int PageNumber { get; private set; } = 1;
    }
}
