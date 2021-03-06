﻿using System.Threading.Tasks;
using JWTAuthentication.Data.Abstract.Repositories.Entity;
using JWTAuthentication.Data.Concrete.EntityFrameworkCore.Contexts;
using JWTAuthentication.Data.Concrete.EntityFrameworkCore.Repositories.Entity;
using JWTAuthentication.Data.UnitOfWorks.Abstract;

namespace JWTAuthentication.Data.UnitOfWorks.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly JwtDbContext _context;

        private EfProductRepository _productRepository;
        private EfAppUserRepository _appUserRepository;
        private EfAppRoleRepository _appRoleRepository;
        private EfAppUserRoleRepository _appUserRoleRepository;

        public UnitOfWork(JwtDbContext context)
        {
            _context = context;
        }

        public IProductRepository Product => _productRepository ??= new EfProductRepository(_context);
        public IAppUserRepository AppUser => _appUserRepository ??= new EfAppUserRepository(_context);
        public IAppRoleRepository AppRole => _appRoleRepository ??= new EfAppRoleRepository(_context);
        public IAppUserRoleRepository AppUserRole => _appUserRoleRepository ??= new EfAppUserRoleRepository(_context);

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}
