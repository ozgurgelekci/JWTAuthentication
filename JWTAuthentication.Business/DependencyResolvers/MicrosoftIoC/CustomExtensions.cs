using FluentValidation;
using JWTAuthentication.Data.Abstract.Repositories.Entity;
using JWTAuthentication.Data.Abstract.Repositories.Generic;
using JWTAuthentication.Data.Concrete.EntityFrameworkCore.Repositories.Entity;
using JWTAuthentication.Data.Concrete.EntityFrameworkCore.Repositories.Generic;
using JWTAuthentication.Data.UnitOfWorks.Abstract;
using JWTAuthentication.Data.UnitOfWorks.Concrete;
using JWTAuthentication.Entities.DTOs.Product;
using JWTAuthentication.Services.Abstract.Entity;
using JWTAuthentication.Services.Abstract.Generic;
using JWTAuthentication.Services.Concrete.Entity;
using JWTAuthentication.Services.Concrete.Generic;
using JWTAuthentication.Services.ValidationRules.FluentValidation.Product;
using Microsoft.Extensions.DependencyInjection;

namespace JWTAuthentication.Services.DependencyResolvers.MicrosoftIoC
{
    public static class CustomExtensions
    {
        public static void AddDependencies(this IServiceCollection serviceCollection)
        {
            #region Generic

            serviceCollection.AddScoped(typeof(IGenericService<>), typeof(GenericService<>));
            serviceCollection.AddScoped(typeof(IGenericRepository<>), typeof(EfGenericRepository<>));

            #endregion

            #region Product

            serviceCollection.AddScoped<IProductRepository, EfProductRepository>();
            serviceCollection.AddScoped<IProductService, ProductService>();

            #endregion

            #region AppUser

            serviceCollection.AddScoped<IAppUserRepository, EfAppUserRepository>();
            serviceCollection.AddScoped<IAppUserService, AppUserService>();

            #endregion

            #region AppRole

            serviceCollection.AddScoped<IAppRoleRepository, EfAppRoleRepository>();
            serviceCollection.AddScoped<IAppRoleService, AppRoleService>();

            #endregion

            #region AppUserRole

            serviceCollection.AddScoped<IAppUserRoleRepository, EfAppUserRoleRepository>();
            serviceCollection.AddScoped<IAppUserRoleService, AppUserRoleService>();

            #endregion

            #region UnitOfWork

            serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();

            #endregion

            #region Fluent Validation

            serviceCollection.AddSingleton<IValidator<ProductDto>, ProductDtoValidator>();

            #endregion
        }
    }
}
