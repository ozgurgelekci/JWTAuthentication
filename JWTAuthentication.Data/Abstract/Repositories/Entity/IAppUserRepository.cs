using System.Collections.Generic;
using System.Threading.Tasks;
using JWTAuthentication.Data.Abstract.Repositories.Generic;
using JWTAuthentication.Entities.Concrete;

namespace JWTAuthentication.Data.Abstract.Repositories.Entity
{
    public interface IAppUserRepository : IGenericRepository<AppUser>
    {
        Task<List<AppRole>> GetUserRolesByUserName(string userName);
    }
}
