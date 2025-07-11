using Homely_Web_Api.Models.Residential_Units;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace Homely_Web_Api.Data.Configurations
{
    public class ResidentialUnitConfig : IEntityTypeConfiguration<ResidentialUnit>
    {
        public void Configure(EntityTypeBuilder<ResidentialUnit> builder)
        {
            builder.HasOne(r => r.Location)
                .WithMany(l => l.ResidentialUnits)
                .HasForeignKey(r => r.LocationId);

            builder.HasOne(r => r.Category)
                .WithMany(c => c.ResidentialUnits)
                .HasForeignKey(r => r.CategoryId);

            builder.HasOne(r => r.Host)
                .WithMany(u => u.ResidentialUnits)
                .HasForeignKey(r => r.HostId);

            builder.Property(u => u.Price)
                .HasPrecision(5, 2);

        }
    }
}
