using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Domain.Interfacse
{
    public interface ISpecification<TEntity> where TEntity : class, IAggregateRoot
    {
        Expression<Func<TEntity, bool>>? FilterExpression { get; }
        List<Expression<Func<TEntity, object>>> IncludeExpressions { get; }
        List<OrderByParam<TEntity>> OrderByExpressions { get; }
    }
}
