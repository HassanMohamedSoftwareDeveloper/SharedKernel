using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public class PagedList<TResult> : List<TResult>
    {
        public PagedList(IEnumerable<TResult> items, int count, int pageNumber, int pageSize)
        {
            CurrentPage = pageNumber;
            TotalPages = (int)Math.Ceiling(count / ((double)pageSize));
            PageSize = pageSize;
            TotalCount = count;
            AddRange(items);
        }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
    }
}
