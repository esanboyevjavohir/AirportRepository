﻿using Airways.Core.Common;
using Airways.Core.Entity;
using System.Linq.Expressions;

namespace Airways.DataAccess.Repository
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity> GetFirstAsync(Expression<Func<TEntity, bool>> predicate);

        Task<User> GetByIdAsync(Guid entity);
        Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate);
        IQueryable<TEntity> GetAll();
        IEnumerable<TEntity> GetAllAsEnumurable();

        Task<TEntity> AddAsync(TEntity entity);

        Task<TEntity> UpdateAsync(TEntity entity);

        Task<TEntity> DeleteAsync(TEntity entity);
    }

}
