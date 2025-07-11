using Homely_Web_Api.Models;
using Homely_Web_Api.Models.Residential_Units;
using Microsoft.EntityFrameworkCore;

namespace Homely_Web_Api.Data
{
    public class AppDbContext : DbContext 
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<AppUserRole> AppUserRoles { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }

        public DbSet<ResidentialUnit> ResidentialUnits { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Location> Locations { get; set; }

        public DbSet<WishListItem> WishList { get; set; }

        public DbSet<Reservation> Reservations { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }


    }
}
