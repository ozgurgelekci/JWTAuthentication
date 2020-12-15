using FluentValidation;
using JWTAuthentication.Entities.DTOs.AppUser;

namespace JWTAuthentication.Services.ValidationRules.FluentValidation.AppUser
{
    public class AppUserLoginDtoValidator : AbstractValidator<AppUserLoginDto>
    {
        public AppUserLoginDtoValidator()
        {
            RuleFor(x=> x.UserName).NotEmpty().WithMessage("Name is required!");
            RuleFor(x=> x.Password).NotEmpty().WithMessage("Password is required!");
        }
    }
}
