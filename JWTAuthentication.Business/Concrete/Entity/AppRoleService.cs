using JWTAuthentication.Data.Abstract.Repositories.Generic;
using JWTAuthentication.Entities.Concrete;
using JWTAuthentication.Services.Abstract.Entity;
using JWTAuthentication.Services.Concrete.Generic;

namespace JWTAuthentication.Services.Concrete.Entity
{
    public class AppRoleService : GenericService<AppRole>, IAppRoleService
    {
        public AppRoleService(IGenericRepository<AppRole> genericRepository) : base(genericRepository)
        {
        }
    }
}
