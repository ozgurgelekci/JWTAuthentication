using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using JWTAuthentication.Entities.Concrete;
using JWTAuthentication.Services.Abstract.Jwt;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace JWTAuthentication.Services.Concrete.Jwt
{
    public class JwtService : IJwtService
    {
        private IConfiguration Configuration { get; }
        public JwtService(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public string GenerateJtw(AppUser appUser, List<AppRole> roles)
        {
            SymmetricSecurityKey symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JwtOptions:Key"]));

            SigningCredentials signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(Configuration["JwtOptions:Issuer"],
                Configuration["JwtOptions:Issuer"],
                expires: DateTime.Now.AddMinutes(1),
                signingCredentials: signingCredentials, claims: GetClaims(appUser, roles));

            return new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
        }

        private List<Claim> GetClaims(AppUser appUser, List<AppRole> roles)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, appUser.UserName),
                new Claim(ClaimTypes.NameIdentifier, appUser.Id.ToString())
            };

            if (roles?.Count > 0)
            {
                claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role.Name)));
            }

            return claims;
        }
    }
}
