using JWTAuthentication.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JWTAuthentication.Data.Seeds
{
    public class AppRoleSeed : IEntityTypeConfiguration<AppRole>
    {
        public void Configure(EntityTypeBuilder<AppRole> builder)
        {
            builder.HasData(new AppRole { Id = 1, Name = "Admin" });
            builder.HasData(new AppRole { Id = 2, Name = "Member" });
        }
    }
}
