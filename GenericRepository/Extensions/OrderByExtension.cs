using SharedKernel.Models.Common;
using SharedKernel.Models.Specifications;
using System.Collections.Generic;
using System.Linq;

namespace GenericRepository.Extensions
{
    public static class SortingExtension
    {
        public static IQueryable<TEntity> GetOrdering<TEntity>(this IQueryable<TEntity> query, List<OrderByParam<TEntity>> orderByParams)
            where TEntity : class, IAggregateRoot
        {
            IOrderedQueryable<TEntity>? myOrder = null;

            foreach (var orderByParam in orderByParams)
            {
                if (myOrder == null)
                {
                    myOrder = orderByParam.IsOrderByDescending
                        ? query.OrderByDescending(orderByParam.OrderByExpression)
                        : query.OrderBy(orderByParam.OrderByExpression);
                }
                else
                {
                    myOrder = orderByParam.IsOrderByDescending
                        ? myOrder.ThenByDescending(orderByParam.OrderByExpression)
                        : myOrder.ThenBy(orderByParam.OrderByExpression);
                }
            }
            return query;
        }
    }
}
