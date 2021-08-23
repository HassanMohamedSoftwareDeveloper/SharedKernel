using Microsoft.EntityFrameworkCore;
using Domain.Interfacse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Infrastructure.Extensions;
using Domain.Models;

namespace Infrastructure.Repos
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IAggregateRoot
    {
        #region Fields :
        protected readonly DbContext Context;
        private readonly DbSet<TEntity> _dbSet;
        #endregion
        #region CTORS :
        public Repository(DbContext dbContext)
        {
            this.Context = dbContext;
            _dbSet = dbContext.Set<TEntity>();
        }
        #endregion
        #region Queries :
        //--------------------------------------Find-------------------------------------
        public async Task<TEntity> GetByIdAsync(params object[] ids)
        {
            return await _dbSet.FindAsync(ids).ConfigureAwait(false);
        }
        //--------------------------------------Get All-------------------------------------
        public async Task<IEnumerable<TEntity>> GetAllAsync(ISpecification<TEntity>? specification = null)
        {
            return await _dbSet.GetQuery(specification).ToListAsync().ConfigureAwait(false);
        }
        public async Task<IEnumerable<TResult>> GetAllAsync<TResult>(Expression<Func<TEntity, TResult>> selector, ISpecification<TEntity>? specification = null)
        {
            return await _dbSet.GetQuery(specification).GetQueryWithProjection(selector).ToListAsync().ConfigureAwait(false);
        }
        public async Task<IEnumerable<TResult>> GetAllAsync<TResult>(Expression<Func<TEntity, IEnumerable<TResult>>> selector, ISpecification<TEntity>? specification = null)
        {
            return await _dbSet.GetQuery(specification).GetQueryWithProjection(selector).ToListAsync().ConfigureAwait(false);
        }
        //--------------------------------------Get Query-------------------------------------
        public IQueryable<TEntity> GetQueryAsync<TResult>(ISpecification<TEntity>? specification = null)
        {
            return _dbSet.GetQuery(specification);
        }
        //--------------------------------------Get Single-------------------------------------
        public async Task<TEntity> GetSingleOrDefaultAsync(ISpecification<TEntity>? specification = null)
        {
            return await _dbSet.GetQuery(specification).SingleOrDefaultAsync().ConfigureAwait(false);
        }
        public async Task<TResult> GetSingleOrDefaultAsync<TResult>(Expression<Func<TEntity, TResult>> selector, ISpecification<TEntity>? specification = null)
        {
            return await _dbSet.GetQuery(specification).GetQueryWithProjection(selector).SingleOrDefaultAsync().ConfigureAwait(false);
        }
        public async Task<TResult> GetSingleOrDefaultAsync<TResult>(Expression<Func<TEntity, IEnumerable<TResult>>> selector, ISpecification<TEntity>? specification = null)
        {
            return await _dbSet.GetQuery(specification).GetQueryWithProjection(selector).SingleOrDefaultAsync().ConfigureAwait(false);
        }
        //--------------------------------------Get First-------------------------------------
        public async Task<TEntity> GetFirstOrDefaultAsync(ISpecification<TEntity>? specification = null)
        {
            return await _dbSet.GetQuery(specification).FirstOrDefaultAsync().ConfigureAwait(false);
        }
        public async Task<TResult> GetFirstOrDefaultAsync<TResult>(Expression<Func<TEntity, TResult>> selector, ISpecification<TEntity>? specification = null)
        {
            return await _dbSet.GetQuery(specification).GetQueryWithProjection(selector).FirstOrDefaultAsync().ConfigureAwait(false);
        }
        public async Task<TResult> GetFirstOrDefaultAsync<TResult>(Expression<Func<TEntity, IEnumerable<TResult>>> selector, ISpecification<TEntity>? specification = null)
        {
            return await _dbSet.GetQuery(specification).GetQueryWithProjection(selector).FirstOrDefaultAsync().ConfigureAwait(false);
        }
        //--------------------------------------Get Count-------------------------------------
        public async Task<int> GetCountAsync(ISpecification<TEntity>? specification = null)
        {
            return await _dbSet.GetQuery(specification).CountAsync().ConfigureAwait(false);
        }
        //--------------------------------------Get Page-------------------------------------
        public async Task<PagedList<TEntity>> GetPagedAsync(PagingParam paging, ISpecification<TEntity>? specification = null)
        {
            return await _dbSet.GetQuery(specification).CreatePagingAsync(paging).ConfigureAwait(false);
        }
        public async Task<PagedList<TResult>> GetPagedAsync<TResult>(Expression<Func<TEntity, TResult>> selector, PagingParam paging, ISpecification<TEntity>? specification = null)
        {
            return await _dbSet.GetQuery(specification).GetQueryWithProjection(selector).CreatePagingAsync(paging).ConfigureAwait(false);
        }
        public async Task<PagedList<TResult>> GetPagedAsync<TResult>(Expression<Func<TEntity, IEnumerable<TResult>>> selector, PagingParam paging, ISpecification<TEntity>? specification = null)
        {
            return await _dbSet.GetQuery(specification).GetQueryWithProjection(selector).CreatePagingAsync(paging).ConfigureAwait(false);
        }
        #endregion
        #region Commands :
        //--------------------------------------Add-------------------------------------
        public virtual void Add(TEntity entity)
        {
             _dbSet.AddAsync(entity);
        }
        public virtual void AddRange(List<TEntity> entities)
        {
            _dbSet.AddRangeAsync(entities);
        }
        //--------------------------------------Remove-------------------------------------
        public virtual void Remove(TEntity entity)
        {
            _dbSet.Remove(entity);
        }
        public virtual void RemoveRange(List<TEntity> entities)
        {
            _dbSet.RemoveRange(entities);
        }
        //--------------------------------------Update-------------------------------------
        public virtual void Update(TEntity entity)
        {
            _dbSet.Update(entity);
        }
        public virtual void UpdateRange(List<TEntity> entities)
        {
            _dbSet.UpdateRange(entities);
        }
        #endregion
    }
}
