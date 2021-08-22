using AutoMapper;
using GenericRepository.Extensions;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Models.Common;
using SharedKernel.Models.Specifications;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GenericRepository.Repos
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
        public async Task<TResult> GetByIdAsync<TResult>(IMapper mapper, params object[] ids)
        {
            var entity = await _dbSet.FindAsync(ids).ConfigureAwait(false);
            return entity.MapTo<TEntity, TResult>(mapper);
        }
        //--------------------------------------Get All-------------------------------------
        public async Task<IEnumerable<TEntity>> GetAllAsync(ISpecification<TEntity>? specification = null)
        {
            return await _dbSet.GetQuery(specification).ToListAsync().ConfigureAwait(false);
        }
        public async Task<IEnumerable<TResult>> GetAllAsync<TResult>(IMapper mapper, ISpecification<TEntity>? specification = null)
        {
            return await _dbSet.GetQuery(specification).GetQueryWithProjection<TEntity, TResult>(mapper).ToListAsync().ConfigureAwait(false);
        }
        public async Task<IEnumerable<TResult>> GetAllAsync<TResult>(Expression<Func<TEntity, TResult>> selector, ISpecification<TEntity>? specification = null)
        {
            return await _dbSet.GetQuery(specification).GetQueryWithProjection(selector).ToListAsync().ConfigureAwait(false);
        }
        public async Task<IEnumerable<TResult>> GetAllAsync<TResult>(Expression<Func<TEntity, IEnumerable<TResult>>> selector, ISpecification<TEntity>? specification = null)
        {
            return await _dbSet.GetQuery(specification).GetQueryWithProjection(selector).ToListAsync().ConfigureAwait(false);
        }
        //--------------------------------------Get Single-------------------------------------
        public async Task<TEntity> GetSingleOrDefaultAsync(ISpecification<TEntity>? specification = null)
        {
            return await _dbSet.GetQuery(specification).SingleOrDefaultAsync().ConfigureAwait(false);
        }
        public async Task<TResult> GetSingleOrDefaultAsync<TResult>(IMapper mapper, ISpecification<TEntity>? specification = null)
        {
            return await _dbSet.GetQuery(specification).GetQueryWithProjection<TEntity, TResult>(mapper).SingleOrDefaultAsync().ConfigureAwait(false);
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
        public async Task<TResult> GetFirstOrDefaultAsync<TResult>(IMapper mapper, ISpecification<TEntity>? specification = null)
        {
            return await _dbSet.GetQuery(specification).GetQueryWithProjection<TEntity, TResult>(mapper).FirstOrDefaultAsync().ConfigureAwait(false);
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
        public async Task<PagedList<TResult>> GetPagedAsync<TResult>(IMapper mapper, PagingParam paging, ISpecification<TEntity>? specification = null)
        {
            return await _dbSet.GetQuery(specification).GetQueryWithProjection<TEntity, TResult>(mapper).CreatePagingAsync(paging).ConfigureAwait(false);
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
        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity).ConfigureAwait(false);
            return entity;
        }
        public virtual async Task AddAsync<TInput>(TInput input, IMapper mapper)
        {
            await _dbSet.AddAsync(input.MapTo<TInput,TEntity>(mapper)).ConfigureAwait(false);
        }
        public virtual async Task AddRangeAsync(List<TEntity> entities)
        {
            await _dbSet.AddRangeAsync(entities).ConfigureAwait(false);
        }
        public virtual async Task AddRangeAsync<TInput>(List<TInput> inputs, IMapper mapper)
        {
            await _dbSet.AddRangeAsync(inputs.MapTo<TInput, TEntity>(mapper)).ConfigureAwait(false);
        }
        //--------------------------------------Remove-------------------------------------
        public virtual Task RemoveAsync(TEntity entity)
        {
            _dbSet.Remove(entity);
            return Task.FromResult(true);
        }
        public virtual Task RemoveRangeAsync(List<TEntity> entities)
        {
            _dbSet.RemoveRange(entities);
            return Task.FromResult(true);
        }
        //--------------------------------------Update-------------------------------------
        public virtual async Task<TEntity> UpdateAsync(TEntity entity)
        {
            return await Task.FromResult(_dbSet.Update(entity).Entity);
        }
        public virtual async Task UpdateAsync<TInput>(TInput input, IMapper mapper,params object[] ids)
        {
            var oldEntity = await GetByIdAsync(ids).ConfigureAwait(false);
            _dbSet.Update(input.MapTo(oldEntity, mapper));
        }
        public virtual Task UpdateRangeAsync(List<TEntity> entities)
        {
            _dbSet.UpdateRange(entities);
            return Task.FromResult(true);
        }
        #endregion
    }
}
