using System.Threading.Tasks;
using JWTAuthentication.Data.Abstract.Repositories.Entity;

namespace JWTAuthentication.Data.UnitOfWorks.Abstract
{
    public interface IUnitOfWork
    {
        public IProductRepository Product { get; }
        public IAppUserRepository AppUser { get; }
        public IAppRoleRepository AppRole { get; }
        public IAppUserRoleRepository AppUserRole { get; }

        Task CommitAsync();
        void Commit();
    }
}
