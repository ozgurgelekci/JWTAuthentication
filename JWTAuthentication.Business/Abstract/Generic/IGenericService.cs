using System.Collections.Generic;
using System.Threading.Tasks;
using JWTAuthentication.Entities.Abstract;

namespace JWTAuthentication.Services.Abstract.Generic
{
    public interface IGenericService<TEntity> where TEntity : class, IEntity, new()
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(int id);
        Task<TEntity> AddAsync(TEntity entity);
        TEntity Update(TEntity entity);
        void Remove(TEntity entity);
    }
}
