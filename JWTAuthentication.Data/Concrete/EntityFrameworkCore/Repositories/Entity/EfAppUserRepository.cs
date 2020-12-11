using JWTAuthentication.Data.Abstract.Repositories.Entity;
using JWTAuthentication.Data.Concrete.EntityFrameworkCore.Contexts;
using JWTAuthentication.Data.Concrete.EntityFrameworkCore.Repositories.Generic;
using JWTAuthentication.Entities.Concrete;

namespace JWTAuthentication.Data.Concrete.EntityFrameworkCore.Repositories.Entity
{
    public class EfAppUserRepository : EfGenericRepository<AppUser>, IAppUserRepository
    {
        public EfAppUserRepository(JwtDbContext context) : base(context)
        {
        }
    }
}
