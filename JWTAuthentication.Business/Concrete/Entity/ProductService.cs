﻿using JWTAuthentication.Data.Abstract.Repositories.Generic;
using JWTAuthentication.Entities.Concrete;
using JWTAuthentication.Services.Abstract.Entity;
using JWTAuthentication.Services.Concrete.Generic;

namespace JWTAuthentication.Services.Concrete.Entity
{
    public class ProductService : GenericService<Product>, IProductService
    {
        public ProductService(IGenericRepository<Product> genericRepository) : base(genericRepository)
        {
        }
    }
}
