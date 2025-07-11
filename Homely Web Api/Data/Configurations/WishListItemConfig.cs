using Homely_Web_Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Homely_Web_Api.Data.Configurations
{
    public class WishListItemConfig : IEntityTypeConfiguration<WishListItem>
    {
        public void Configure(EntityTypeBuilder<WishListItem> builder)
        {
            builder.HasKey(w => w.Id);
            
            builder.HasOne(w => w.User)
                   .WithMany(u => u.WishListItems)
                   .HasForeignKey(w => w.UserId)
                   .OnDelete(DeleteBehavior.Restrict); 

            builder.HasOne(w => w.Unit)
                   .WithMany(u=> u.WishListItems)
                   .HasForeignKey(w => w.UnitId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
    
}
