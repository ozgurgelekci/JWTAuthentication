using JWTAuthentication.Data.Abstract.Repositories.Generic;
using JWTAuthentication.Entities.Concrete;

namespace JWTAuthentication.Data.Abstract.Repositories.Entity
{
    public interface IProductRepository : IGenericRepository<Product>
    {
    }
}
