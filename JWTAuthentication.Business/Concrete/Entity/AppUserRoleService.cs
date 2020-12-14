using JWTAuthentication.Data.Abstract.Repositories.Generic;
using JWTAuthentication.Data.UnitOfWorks.Abstract;
using JWTAuthentication.Entities.Concrete;
using JWTAuthentication.Services.Abstract.Entity;
using JWTAuthentication.Services.Concrete.Generic;

namespace JWTAuthentication.Services.Concrete.Entity
{
    public class AppUserRoleService:GenericService<AppUserRole>,IAppUserRoleService
    {
        public AppUserRoleService(IGenericRepository<AppUserRole> genericRepository, IUnitOfWork unitOfWork) : base(genericRepository, unitOfWork)
        {
        }
    }
}
