using Homely_Web_Api.Models.Residential_Units;

namespace Homely_Web_Api.Models
{
    public class WishListItem
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public AppUser User { get; set; }
        public int UnitId { get; set; }
        public ResidentialUnit Unit { get; set; }

    }
}
