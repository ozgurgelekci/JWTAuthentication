using System.Collections.Generic;
using System.Threading.Tasks;
using JWTAuthentication.Data.Abstract.Repositories.Generic;
using JWTAuthentication.Entities.Abstract;
using JWTAuthentication.Services.Abstract.Generic;


namespace JWTAuthentication.Services.Concrete.Generic
{
    public class GenericService<TEntity> : IGenericService<TEntity> where TEntity : class, IEntity, new()
    {
        private readonly IGenericRepository<TEntity> _genericRepository;

        public GenericService(IGenericRepository<TEntity> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _genericRepository.GetAllAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _genericRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(TEntity entity)
        {
            await _genericRepository.AddAsync(entity);
        }

        public async Task UpdateAsync(TEntity entity)
        {
            await _genericRepository.UpdateAsync(entity);
        }

        public async Task RemoveAsync(TEntity entity)
        {
            await _genericRepository.RemoveAsync(entity);
        }
    }
}
