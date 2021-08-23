using Domain.Interfacse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Infrastructure.Extensions
{
    public static class ProjectionExtension
    {
       
        public static IQueryable<TResult> GetQueryWithProjection<TEntity, TResult>(this IQueryable<TEntity> query, Expression<Func<TEntity, TResult>> selector)
        where TEntity : class, IAggregateRoot
        {
            return query.Select(selector);
        }
        public static IQueryable<TResult> GetQueryWithProjection<TEntity, TResult>(this IQueryable<TEntity> query, Expression<Func<TEntity, IEnumerable<TResult>>> selector)
        where TEntity : class, IAggregateRoot
        {
            return query.SelectMany(selector);
        }
   
    }
}
