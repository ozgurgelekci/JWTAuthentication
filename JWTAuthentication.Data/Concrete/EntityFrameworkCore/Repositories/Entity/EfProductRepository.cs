using JWTAuthentication.Data.Abstract.Repositories.Entity;
using JWTAuthentication.Data.Concrete.EntityFrameworkCore.Contexts;
using JWTAuthentication.Data.Concrete.EntityFrameworkCore.Repositories.Generic;
using JWTAuthentication.Entities.Concrete;

namespace JWTAuthentication.Data.Concrete.EntityFrameworkCore.Repositories.Entity
{
    public class EfProductRepository : EfGenericRepository<Product>, IProductRepository
    {
        public EfProductRepository(JwtDbContext context) : base(context)
        {
        }
    }
}
