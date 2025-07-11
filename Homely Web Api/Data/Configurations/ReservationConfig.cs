using Homely_Web_Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Homely_Web_Api.Data.Configurations
{
    public class ReservationConfig : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder.HasKey(r => r.Id);
            builder.Property(r => r.Status).HasDefaultValue("Pending");
            builder.Property(r => r.Notes).HasMaxLength(500);
            builder.Property(r => r.TotalPrice).HasColumnType("decimal(18,2)");
            builder.Property(r => r.GuestsNum).IsRequired();
            builder.Property(r => r.IdentificationNumber).IsRequired();


            builder.HasOne(r => r.User)
                .WithMany(u => u.Reservations)
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(r => r.Unit)
                .WithMany(u => u.Reservations)
                .HasForeignKey(r => r.UnitId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
   
}
