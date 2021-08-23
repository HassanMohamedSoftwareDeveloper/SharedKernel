using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Interfacse;
using System.Collections.Generic;
using System.Linq;

namespace Application.Extensions
{
    public static class MappingExtension
    {
        public static IQueryable<TResult> GetQueryWithProjection<TEntity, TResult>(this IQueryable<TEntity> query, IMapper mapper)
            where TEntity : class, IAggregateRoot
        {
            return query.ProjectTo<TResult>(mapper.ConfigurationProvider);
        }
        public static TResult MapTo<TFrom, TResult>(this TFrom from, IMapper mapper)
        {
            return mapper.Map<TResult>(from);
        }
        public static List<TResult> MapTo<TFrom, TResult>(this List<TFrom> listFrom, IMapper mapper)
        {
            return mapper.Map<List<TResult>>(listFrom);
        }
        public static TResult MapTo<TFrom, TResult>(this TFrom from, TResult to, IMapper mapper)
        {
            return mapper.Map(from, to);
        }
    }
}
