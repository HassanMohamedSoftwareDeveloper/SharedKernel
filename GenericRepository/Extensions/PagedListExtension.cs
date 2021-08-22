using Microsoft.EntityFrameworkCore;
using SharedKernel.Models.Common;
using System.Linq;
using System.Threading.Tasks;

namespace GenericRepository.Extensions
{
    public static class PagedListExtension
    {
        public static async Task<PagedList<TResult>> CreatePagingAsync<TResult>(this IQueryable<TResult> query, PagingParam paging)
        {
            var count = await query.CountAsync();
            var items = await query.Skip((paging.PageNumber) * paging.PageSize).Take(paging.PageSize).ToListAsync();
            return new PagedList<TResult>(items, count, paging.PageNumber, paging.PageSize);
        }
    }
}
