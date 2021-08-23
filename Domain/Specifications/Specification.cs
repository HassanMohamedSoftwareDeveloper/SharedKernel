using Domain.Interfacse;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Domain.Specifications
{
    public class Specification<TEntity> : ISpecification<TEntity> where TEntity : class, IAggregateRoot
    {
        #region CTORS :
        public Specification()
        {
        }
        public Specification(Expression<Func<TEntity, bool>> filterExpression)
        {
            FilterExpression = filterExpression;
        }
        #endregion
        #region PROPS :
        public Expression<Func<TEntity, bool>>? FilterExpression { get; }
        public List<Expression<Func<TEntity, object>>> IncludeExpressions { get; } = new List<Expression<Func<TEntity, object>>>();
        public List<OrderByParam<TEntity>> OrderByExpressions => new List<OrderByParam<TEntity>>();

        List<OrderByParam<TEntity>> ISpecification<TEntity>.OrderByExpressions => throw new NotImplementedException();
        #endregion
        #region Methods :
        protected void AddIncludeExpression(Expression<Func<TEntity, object>> includeExpression)
        {
            IncludeExpressions.Add(includeExpression);
        }
        protected void AddOrderByExpression(OrderByParam<TEntity> orderByParam)
        {
            OrderByExpressions.Add(orderByParam);
        }
        #endregion
    }
}
