using System.Threading.Tasks;
using JWTAuthentication.Data.Abstract.Repositories.Entity;

namespace JWTAuthentication.Data.UnitOfWorks.Abstract
{
    public interface IUnitOfWork
    {
        IProductRepository Product { get; }

        Task CommitAsync();
        void Commit();
    }
}
