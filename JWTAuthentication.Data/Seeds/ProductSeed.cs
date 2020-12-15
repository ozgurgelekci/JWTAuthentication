using JWTAuthentication.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JWTAuthentication.Data.Seeds
{
    public class ProductSeed : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(new Product { Id = 1, IsDeleted = false, Name = "Pencil" });
            builder.HasData(new Product { Id = 2, IsDeleted = true, Name = "Axe" });
            builder.HasData(new Product { Id = 3, IsDeleted = false, Name = "Orange" });
        }
    }
}
