using SharedKernel.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SharedKernel.Models.Specifications
{
    public interface ISpecification<TEntity> where TEntity : class, IAggregateRoot
    {
        Expression<Func<TEntity, bool>>? FilterExpression { get; }
        List<Expression<Func<TEntity, object>>> IncludeExpressions { get; }
        List<OrderByParam<TEntity>> OrderByExpressions { get; }
    }
}
