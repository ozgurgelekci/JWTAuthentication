using System.Collections.Generic;
using System.Threading.Tasks;
using JWTAuthentication.Entities.Abstract;

namespace JWTAuthentication.Services.Abstract.Generic
{
    public interface IGenericService<TEntity> where TEntity : class, IEntity, new()
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(int id);
        Task AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task RemoveAsync(TEntity entity);
    }
}
