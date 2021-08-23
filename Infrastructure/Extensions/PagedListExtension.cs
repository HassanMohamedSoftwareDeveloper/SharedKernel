using Microsoft.EntityFrameworkCore;
using Domain.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Extensions
{
    public static class PagedListExtension
    {
        public static async Task<PagedList<TResult>> CreatePagingAsync<TResult>(this IQueryable<TResult> query, PagingParam paging)
        {
            var count = await query.CountAsync();
            var items = await query.Skip(paging.PageNumber * paging.PageSize).Take(paging.PageSize).ToListAsync();
            return new PagedList<TResult>(items, count, paging.PageNumber, paging.PageSize);
        }
        public static PagedList<TResult> CreatePaging<TResult>(this IEnumerable<TResult> query, PagingParam paging)
        {
            var count = query.Count();
            var items = query.Skip(paging.PageNumber * paging.PageSize).Take(paging.PageSize);
            return new PagedList<TResult>(items, count, paging.PageNumber, paging.PageSize);
        }
    }
}
