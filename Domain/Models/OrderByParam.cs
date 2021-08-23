using Domain.Interfacse;
using System;
using System.Linq.Expressions;

namespace Domain.Models
{
    public class OrderByParam<TEntity> where TEntity : class, IAggregateRoot
    {
        public OrderByParam(Expression<Func<TEntity, object>> orderByExpression, bool isOrderByDescending = default)
        {
            this.OrderByExpression = orderByExpression;
            this.IsOrderByDescending = isOrderByDescending;
        }
        public Expression<Func<TEntity, object>> OrderByExpression { get; private set; }
        public bool IsOrderByDescending { get; private set; }
    }
}
