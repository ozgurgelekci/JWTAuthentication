using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JWTAuthentication.Data.Abstract.Repositories.Entity;
using JWTAuthentication.Data.Concrete.EntityFrameworkCore.Contexts;
using JWTAuthentication.Data.Concrete.EntityFrameworkCore.Repositories.Generic;
using JWTAuthentication.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace JWTAuthentication.Data.Concrete.EntityFrameworkCore.Repositories.Entity
{
    public class EfAppUserRepository : EfGenericRepository<AppUser>, IAppUserRepository
    {
        private JwtDbContext _jwtDbContext { get => _context as JwtDbContext; }

        public EfAppUserRepository(JwtDbContext context) : base(context)
        {
        }

        public async Task<List<AppRole>> GetUserRolesByUserName(string userName)
        {
            return await _jwtDbContext.AppUsers.Join(_jwtDbContext.AppUserRoles, u => u.Id, ur => ur.AppUserId, (user, userRole) => new
            {
                user = user,
                userRole = userRole
            }).Join(_jwtDbContext.AppRoles, two => two.userRole.AppRoleId, r => r.Id, (twoTable, role) => new
            {
                user = twoTable.user,
                userRole = twoTable.userRole,
                role = role
            }).Where(u => u.user.UserName == userName).Select(x => new AppRole
            {
                Id = x.role.Id,
                Name = x.role.Name
            }).ToListAsync();
        }
    }
}
