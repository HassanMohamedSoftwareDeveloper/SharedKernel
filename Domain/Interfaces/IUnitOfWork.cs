using System.Threading;
using System.Threading.Tasks;

namespace Domain.Interfacse
{
    public partial interface IUnitOfWork
    {
        #region Methods :
        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class, IAggregateRoot;
        Task<int> CompleteAsync();
        Task<int> CompleteAsync(CancellationToken cancellationToken);
        bool HasChanges();
        #endregion
    }
}
