using GenericRepository.Repos;
using SharedKernel.Models.Common;
using System.Threading;
using System.Threading.Tasks;

namespace GenericRepository.UOW
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
