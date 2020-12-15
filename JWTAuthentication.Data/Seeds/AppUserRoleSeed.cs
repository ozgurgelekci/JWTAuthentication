using JWTAuthentication.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JWTAuthentication.Data.Seeds
{
    public class AppUserRoleSeed : IEntityTypeConfiguration<AppUserRole>
    {
        public void Configure(EntityTypeBuilder<AppUserRole> builder)
        {
            builder.HasData(new AppUserRole { Id = 1, AppRoleId = 1, AppUserId = 1 });
            builder.HasData(new AppUserRole { Id = 2, AppRoleId = 2, AppUserId = 2 });
            builder.HasData(new AppUserRole { Id = 3, AppRoleId = 1, AppUserId = 3 });
        }
    }
}
