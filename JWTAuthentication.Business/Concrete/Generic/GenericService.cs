using System.Collections.Generic;
using System.Threading.Tasks;
using JWTAuthentication.Data.Abstract.Repositories.Generic;
using JWTAuthentication.Data.UnitOfWorks.Abstract;
using JWTAuthentication.Entities.Abstract;
using JWTAuthentication.Services.Abstract.Generic;


namespace JWTAuthentication.Services.Concrete.Generic
{
    public class GenericService<TEntity> : IGenericService<TEntity> where TEntity : class, IEntity, new()
    {
        private readonly IGenericRepository<TEntity> _genericRepository;
        public readonly IUnitOfWork _unitOfWork;

        public GenericService(IGenericRepository<TEntity> genericRepository, IUnitOfWork unitOfWork)
        {
            _genericRepository = genericRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _genericRepository.GetAllAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _genericRepository.GetByIdAsync(id);
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await _genericRepository.AddAsync(entity);
            await _unitOfWork.CommitAsync();
            return entity;
        }

        public TEntity Update(TEntity entity)
        {
            TEntity tEntity = _genericRepository.Update(entity);
            _unitOfWork.Commit();
            return tEntity;
        }

        public void Remove(TEntity entity)
        {
            _genericRepository.Remove(entity);
            _unitOfWork.Commit();
        }
    }
}
