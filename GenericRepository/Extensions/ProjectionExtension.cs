using AutoMapper;
using AutoMapper.QueryableExtensions;
using SharedKernel.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace GenericRepository.Extensions
{
    public static class ProjectionExtension
    {
        public static IQueryable<TResult> GetQueryWithProjection<TEntity, TResult>(this IQueryable<TEntity> query, IMapper mapper)
            where TEntity : class, IAggregateRoot
        {
            return query.ProjectTo<TResult>(mapper.ConfigurationProvider);
        }
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
        public static TResult MapTo<TFrom, TResult>(this TFrom from, IMapper mapper)
        {
            return mapper.Map<TResult>(from);
        }
        public static List<TResult> MapTo<TFrom, TResult>(this List<TFrom> listFrom, IMapper mapper)
        {
            return mapper.Map<List<TResult>>(listFrom);
        }
        public static TResult MapTo<TFrom, TResult>(this TFrom from,TResult to, IMapper mapper)
        {
            return mapper.Map(from,to);
        }
    }
}
