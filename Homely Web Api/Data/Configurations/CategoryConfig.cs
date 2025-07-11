using Homely_Web_Api.Models.Residential_Units;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Homely_Web_Api.Data.Configurations
{
    public class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(
                new Category { Id = 1, Name = "room" },
                new Category { Id = 2, Name = "luxe" },
                new Category { Id = 3, Name = "beachfront" },
                new Category { Id = 4, Name = "island" },
                new Category { Id = 5, Name = "cabin" },
                new Category { Id = 6, Name = "treehouse" },
                new Category { Id = 7, Name = "mansions" }

            );
        }
    }
}
