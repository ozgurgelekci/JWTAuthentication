using JWTAuthentication.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JWTAuthentication.Data.Seeds
{
    public class AppUserSeed : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.HasData(new AppUser { Id = 1, UserName = "User1", Password = "1", FullName = "User 1" });
            builder.HasData(new AppUser { Id = 2, UserName = "User2", Password = "1", FullName = "User 2" });
            builder.HasData(new AppUser { Id = 3, UserName = "User3", Password = "1", FullName = "User 3" });
        }
    }
}
