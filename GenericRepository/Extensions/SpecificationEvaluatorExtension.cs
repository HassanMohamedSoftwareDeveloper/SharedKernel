﻿using Microsoft.EntityFrameworkCore;
using SharedKernel.Models.Common;
using SharedKernel.Models.Specifications;
using System.Linq;

namespace GenericRepository.Extensions
{
    public static class SpecificationEvaluatorExtension
    {
        public static IQueryable<TEntity> GetQuery<TEntity>(this IQueryable<TEntity> query, ISpecification<TEntity>? specification)
            where TEntity : class, IAggregateRoot
        {
            if (specification == null) return query;
            if (specification.FilterExpression != null) query = query.Where(specification.FilterExpression);
            query = query.GetOrdering(specification.OrderByExpressions);
            query = specification.IncludeExpressions.Aggregate(query, (current, include) => current.Include(include));
            return query;
        }
    }
}
