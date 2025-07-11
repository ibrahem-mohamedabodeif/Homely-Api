using Homely_Web_Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Homely_Web_Api.Data.Configurations
{
    public class UserRoleConfig : IEntityTypeConfiguration<AppUserRole>
    {
        public void Configure(EntityTypeBuilder<AppUserRole> builder)
        {
            builder.HasKey(u => new { u.AppUserId, u.RoleId });

            builder.HasOne(u => u.AppUser)
                .WithMany(ur => ur.AppUserRoles)
                .HasForeignKey(u => u.AppUserId);

            builder.HasOne(u => u.Role)
                .WithMany(ur => ur.AppUserRoles)
                .HasForeignKey(u => u.RoleId);
        }
    }
}
