using System.Collections.Generic;
using JWTAuthentication.Entities.Concrete;
using JWTAuthentication.Entities.DTOs.AppUser;
using JWTAuthentication.Services.Abstract.Generic;

namespace JWTAuthentication.Services.Abstract.Entity
{
    public interface IAppUserService : IGenericService<AppUser>
    {
        AppUser FindByUserNameAndPassword(AppUserLoginDto appUserLoginDto);
        List<AppRole> GetUserRolesByUserName(string userName);
    }
}
