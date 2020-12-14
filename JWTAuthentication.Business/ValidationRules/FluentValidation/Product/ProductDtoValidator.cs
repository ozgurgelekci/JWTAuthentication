using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using JWTAuthentication.Entities.DTOs.Product;

namespace JWTAuthentication.Services.ValidationRules.FluentValidation.Product
{
    public class ProductDtoValidator : AbstractValidator<ProductDto>
    {
        public ProductDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
        }
    }
}
