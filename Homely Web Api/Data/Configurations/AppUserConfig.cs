using Homely_Web_Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Homely_Web_Api.Data.Configurations
{
    public class AppUserConfig :IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property(u => u.FirstName).IsRequired().HasMaxLength(256);
            builder.Property(u => u.LastName).IsRequired().HasMaxLength(256);
            builder.Property(u => u.Email).IsRequired().HasMaxLength(256);
            builder.HasIndex(u => u.Email).IsUnique();
            builder.Property(u => u.PasswordHash).IsRequired();

            builder.HasMany(u => u.RefreshTokens)
                .WithOne(rt => rt.AppUser)
                .HasForeignKey(rt => rt.AppUserId);
        }
    }
   
}
