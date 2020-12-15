using System.Collections.Generic;
using JWTAuthentication.Entities.Concrete;

namespace JWTAuthentication.Services.Abstract.Jwt
{
    public interface IJwtService
    {
        string GenerateJtw(AppUser appUser, List<AppRole> roles);
    }
}
