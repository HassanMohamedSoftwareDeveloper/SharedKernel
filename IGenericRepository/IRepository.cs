using SharedKernel.Models.Common;
using SharedKernel.Models.Specifications;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace IGenericRepository
{
    public interface IRepository<TEntity> where TEntity : class, IAggregateRoot
    {
        #region Queries :
        //--------------------------------------Find-------------------------------------
        Task<TEntity> GetByIdAsync(params object[] ids);
        Task<TResult> GetByIdAsync<TResult>(params object[] ids);
        //--------------------------------------Get All-------------------------------------
        Task<IEnumerable<TEntity>> GetAllAsync(ISpecification<TEntity>? specification = null);
        Task<IEnumerable<TResult>> GetAllAsync<TResult>(ISpecification<TEntity>? specification = null);
        Task<IEnumerable<TResult>> GetAllAsync<TResult>(Expression<Func<TEntity, TResult>> selector, ISpecification<TEntity>? specification = null);
        Task<IEnumerable<TResult>> GetAllAsync<TResult>(Expression<Func<TEntity, IEnumerable<TResult>>> selector, ISpecification<TEntity>? specification = null);
        //--------------------------------------Get Single-------------------------------------
        Task<TEntity> GetSingleOrDefaultAsync(ISpecification<TEntity>? specification = null);
        Task<TResult> GetSingleOrDefaultAsync<TResult>(ISpecification<TEntity>? specification = null);
        Task<TResult> GetSingleOrDefaultAsync<TResult>(Expression<Func<TEntity, TResult>> selector, ISpecification<TEntity>? specification = null);
        Task<TResult> GetSingleOrDefaultAsync<TResult>(Expression<Func<TEntity, IEnumerable<TResult>>> selector, ISpecification<TEntity>? specification = null);
        //--------------------------------------Get First-------------------------------------
        Task<TEntity> GetFirstOrDefaultAsync(ISpecification<TEntity>? specification = null);
        Task<TResult> GetFirstOrDefaultAsync<TResult>(ISpecification<TEntity>? specification = null);
        Task<TResult> GetFirstOrDefaultAsync<TResult>(Expression<Func<TEntity, TResult>> selector, ISpecification<TEntity>? specification = null);
        Task<TResult> GetFirstOrDefaultAsync<TResult>(Expression<Func<TEntity, IEnumerable<TResult>>> selector, ISpecification<TEntity>? specification = null);
        //--------------------------------------Get Count-------------------------------------
        Task<int> GetCountAsync(ISpecification<TEntity>? specification = null);
        //--------------------------------------Get Page-------------------------------------
        Task<PagedList<TEntity>> GetPagedAsync(PagingParam paging, ISpecification<TEntity>? specification = null);
        Task<PagedList<TResult>> GetPagedAsync<TResult>(PagingParam paging, ISpecification<TEntity>? specification = null);
        Task<PagedList<TResult>> GetPagedAsync<TResult>(Expression<Func<TEntity, TResult>> selector, PagingParam paging, ISpecification<TEntity>? specification = null);
        Task<PagedList<TResult>> GetPagedAsync<TResult>(Expression<Func<TEntity, IEnumerable<TResult>>> selector, PagingParam paging, ISpecification<TEntity>? specification = null);
        #endregion
        #region Commands :
        //--------------------------------------Add-------------------------------------
        Task<TEntity> AddAsync(TEntity entity);
        Task AddAsync<TInput>(TInput input);
        Task AddRangeAsync(List<TEntity> entities);
        Task AddRangeAsync<TInput>(List<TInput> inputs);
        //--------------------------------------Remove-------------------------------------
        Task RemoveAsync(TEntity entity);
        Task RemoveRangeAsync(List<TEntity> entities);
        //--------------------------------------Update-------------------------------------
        Task<TEntity> UpdateAsync(TEntity entity);
        Task UpdateAsync<TInput>(TInput input, params object[] ids);
        Task UpdateRangeAsync(List<TEntity> entities);
        #endregion
    }
}
