using GenericRepository.Repos;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Models.Common;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GenericRepository.UOW
{
    public partial class UnitOfWork : IUnitOfWork, IAsyncDisposable
    {
        #region Fields :
        private readonly DbContext _dbContext;
        #endregion
        #region CTORS :
        public UnitOfWork(DbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        #endregion
        #region Methods :
        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class, IAggregateRoot
        {
            return new Repository<TEntity>(_dbContext);
        }
        public async Task<int> CompleteAsync()
        {
            return await _dbContext.SaveChangesAsync().ConfigureAwait(false);
        }
        public async Task<int> CompleteAsync(CancellationToken cancellationToken)
        {
            return await _dbContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
        public bool HasChanges()
        {
            _dbContext.ChangeTracker.DetectChanges();
            return _dbContext.ChangeTracker.HasChanges();
        }
        /// <summary>
        /// No matter an exception has been raised or not, this method always will dispose the DbContext 
        /// </summary>
        /// <returns></returns>
        public ValueTask DisposeAsync()
        {
            return _dbContext.DisposeAsync();
        }
        #endregion
    }
}
