using System.Threading.Tasks;
using JWTAuthentication.Data.Abstract.Repositories.Entity;
using JWTAuthentication.Data.Concrete.EntityFrameworkCore.Contexts;
using JWTAuthentication.Data.Concrete.EntityFrameworkCore.Repositories.Entity;
using JWTAuthentication.Data.UnitOfWorks.Abstract;

namespace JWTAuthentication.Data.UnitOfWorks.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly JwtDbContext _context;

        private EfProductRepository _productRepository;

        public UnitOfWork(JwtDbContext context)
        {
            _context = context;
        }

        public IProductRepository Product => _productRepository ??= new EfProductRepository(_context);
        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}
