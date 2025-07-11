using Homely_Web_Api.Models.Residential_Units;

namespace Homely_Web_Api.Models
{
    public class AppUser
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public ICollection<AppUserRole> AppUserRoles { get; set; } = new List<AppUserRole>();
        public ICollection<RefreshToken> RefreshTokens { get; set; } = new List<RefreshToken>();

        public ICollection<ResidentialUnit> ResidentialUnits { get; set; } = new List<ResidentialUnit>();
        public ICollection<WishListItem> WishListItems { get; set; } = new List<WishListItem>();
        public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();

    }
}
