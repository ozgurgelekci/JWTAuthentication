using JWTAuthentication.Entities.DTOs.AppUser;
using JWTAuthentication.Services.Abstract.Entity;
using JWTAuthentication.Services.Abstract.Jwt;
using JWTAuthentication.WebApi.Filters;
using Microsoft.AspNetCore.Mvc;

namespace JWTAuthentication.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly IJwtService _jwtService;
        private readonly IAppUserService _appUserService;

        public AuthController(IJwtService jwtService, IAppUserService appUserService)
        {
            _jwtService = jwtService;
            _appUserService = appUserService;
        }

        [HttpPost("[action]")]
        [ValidationFilter]
        public IActionResult SignIn(AppUserLoginDto appUserLoginDto)
        {
            var appUser = _appUserService.FindByUserNameAndPassword(appUserLoginDto);
            if (appUser == null)
            {
                return BadRequest(new { status = 403, message = "Incorrect Username or Password" });
            }
            else
            {
                var roles = _appUserService.GetUserRolesByUserName(appUserLoginDto.UserName);
                var token = _jwtService.GenerateJtw(appUser, roles);
                return Created("", token);
            }
        }

    }
}
