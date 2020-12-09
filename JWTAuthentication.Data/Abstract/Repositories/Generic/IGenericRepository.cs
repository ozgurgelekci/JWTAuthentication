using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using JWTAuthentication.Entities.Abstract;

namespace JWTAuthentication.Data.Abstract.Repositories.Generic
{
    public interface IGenericRepository<TEntity> where TEntity : class, IEntity, new()
    {
        Task<IEnumerable<TEntity>> GetAll();
        Task<IEnumerable<TEntity>> GetAllByFilter(Expression<Func<TEntity, bool>> filter);
        Task<TEntity> GetById(int id);
        Task<TEntity> GetByFilter(Expression<Func<TEntity, bool>> filter);
        Task Add(TEntity entity);
        Task Update(TEntity entity);
        Task Remove(TEntity entity);
    }
}
