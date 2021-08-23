using Domain.Interfacse;
using Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Extensions
{
    public static class SortingExtension
    {
        public static IQueryable<TEntity> GetOrdering<TEntity>(this IQueryable<TEntity> query, List<OrderByParam<TEntity>> orderByParams)
            where TEntity : class, IAggregateRoot
        {
            if (orderByParams == null || orderByParams.Any() == default) return query;

            var orderBy = orderByParams[0];

            IOrderedQueryable<TEntity> queryWithOrders = query.ApplyOrderBy(orderBy);


            for (int index = 1; index < orderByParams.Count; index++)
            {
                var orderByParam = orderByParams[index];
                queryWithOrders = queryWithOrders.ApplyThenOrderBy(orderByParam);
            }

            return queryWithOrders;
        }
        private static IOrderedQueryable<TEntity> ApplyOrderBy<TEntity>(this IQueryable<TEntity> query, OrderByParam<TEntity> orderBy) where TEntity : class, IAggregateRoot
        {
            return orderBy.IsOrderByDescending ? query.OrderByDescending(orderBy.OrderByExpression) : query.OrderBy(orderBy.OrderByExpression);
        }
        private static IOrderedQueryable<TEntity> ApplyThenOrderBy<TEntity>(this IOrderedQueryable<TEntity> queryWithOrder, OrderByParam<TEntity> orderByParam) where TEntity : class, IAggregateRoot
        {
            return orderByParam.IsOrderByDescending ? queryWithOrder.ThenByDescending(orderByParam.OrderByExpression) : queryWithOrder.ThenBy(orderByParam.OrderByExpression);
        }
    }
}
