using JWTAuthentication.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JWTAuthentication.Data.Concrete.EntityFrameworkCore.Configurations
{
    public class AppUserRoleConfiguration:IEntityTypeConfiguration<AppUserRole>
    {
        public void Configure(EntityTypeBuilder<AppUserRole> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.HasIndex(x => new {x.AppUserId, x.AppRoleId}).IsUnique();

            builder.ToTable("AppUserRoles");
        }
    }
}
