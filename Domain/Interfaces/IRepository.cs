using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Domain.Interfacse
{
    public interface IRepository<TEntity> where TEntity : class, IAggregateRoot
    {
        #region Queries :
        //--------------------------------------Find-------------------------------------
        Task<TEntity> GetByIdAsync(params object[] ids);
        //--------------------------------------Get All-------------------------------------
        Task<IEnumerable<TEntity>> GetAllAsync(ISpecification<TEntity>? specification = null);
        Task<IEnumerable<TResult>> GetAllAsync<TResult>(Expression<Func<TEntity, TResult>> selector, ISpecification<TEntity>? specification = null);
        Task<IEnumerable<TResult>> GetAllAsync<TResult>(Expression<Func<TEntity, IEnumerable<TResult>>> selector, ISpecification<TEntity>? specification = null);
        //--------------------------------------Get Query-------------------------------------
        IQueryable<TEntity> GetQueryAsync<TResult>(ISpecification<TEntity>? specification = null);
        //--------------------------------------Get Single-------------------------------------
        Task<TEntity> GetSingleOrDefaultAsync(ISpecification<TEntity>? specification = null);
        Task<TResult> GetSingleOrDefaultAsync<TResult>(Expression<Func<TEntity, TResult>> selector, ISpecification<TEntity>? specification = null);
        Task<TResult> GetSingleOrDefaultAsync<TResult>(Expression<Func<TEntity, IEnumerable<TResult>>> selector, ISpecification<TEntity>? specification = null);
        //--------------------------------------Get First-------------------------------------
        Task<TEntity> GetFirstOrDefaultAsync(ISpecification<TEntity>? specification = null);
        Task<TResult> GetFirstOrDefaultAsync<TResult>(Expression<Func<TEntity, TResult>> selector, ISpecification<TEntity>? specification = null);
        Task<TResult> GetFirstOrDefaultAsync<TResult>(Expression<Func<TEntity, IEnumerable<TResult>>> selector, ISpecification<TEntity>? specification = null);
        //--------------------------------------Get Count-------------------------------------
        Task<int> GetCountAsync(ISpecification<TEntity>? specification = null);
        //--------------------------------------Get Page-------------------------------------
        Task<PagedList<TEntity>> GetPagedAsync(PagingParam paging, ISpecification<TEntity>? specification = null);
        Task<PagedList<TResult>> GetPagedAsync<TResult>(Expression<Func<TEntity, TResult>> selector, PagingParam paging, ISpecification<TEntity>? specification = null);
        Task<PagedList<TResult>> GetPagedAsync<TResult>(Expression<Func<TEntity, IEnumerable<TResult>>> selector, PagingParam paging, ISpecification<TEntity>? specification = null);
        #endregion
        #region Commands :
        //--------------------------------------Add-------------------------------------
        void Add(TEntity entity);
        void AddRange(List<TEntity> entities);
        //--------------------------------------Remove-------------------------------------
        void Remove(TEntity entity);
        void RemoveRange(List<TEntity> entities);
        //--------------------------------------Update-------------------------------------
        void Update(TEntity entity);
        void UpdateRange(List<TEntity> entities);
        #endregion
    }
}
