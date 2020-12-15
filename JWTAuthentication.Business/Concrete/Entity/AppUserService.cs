using System.Collections.Generic;
using JWTAuthentication.Data.Abstract.Repositories.Generic;
using JWTAuthentication.Data.UnitOfWorks.Abstract;
using JWTAuthentication.Entities.Concrete;
using JWTAuthentication.Entities.DTOs.AppUser;
using JWTAuthentication.Services.Abstract.Entity;
using JWTAuthentication.Services.Concrete.Generic;

namespace JWTAuthentication.Services.Concrete.Entity
{
    public class AppUserService : GenericService<AppUser>, IAppUserService
    {

        public AppUserService(IGenericRepository<AppUser> genericRepository, IUnitOfWork unitOfWork) : base(genericRepository, unitOfWork)
        {
        }

        public AppUser FindByUserNameAndPassword(AppUserLoginDto appUserLoginDto)
        {
            return _unitOfWork.AppUser.GetByFilterAsync(x => x.UserName == appUserLoginDto.UserName && x.Password == appUserLoginDto.Password).Result;
        }

        public List<AppRole> GetUserRolesByUserName(string userName)
        {
            return _unitOfWork.AppUser.GetUserRolesByUserName(userName).Result;
        }
    }
}
