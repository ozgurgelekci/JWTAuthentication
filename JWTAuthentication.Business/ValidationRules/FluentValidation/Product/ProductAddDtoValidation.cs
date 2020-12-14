using FluentValidation;
using JWTAuthentication.Entities.DTOs.Product;

namespace JWTAuthentication.Services.ValidationRules.FluentValidation.Product
{
    public class ProductAddDtoValidation : AbstractValidator<ProductDto>
    {
        public ProductAddDtoValidation()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required!");
        }
    }
}
