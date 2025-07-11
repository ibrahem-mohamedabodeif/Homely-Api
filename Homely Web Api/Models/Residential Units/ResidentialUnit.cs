namespace Homely_Web_Api.Models.Residential_Units
{
    public class ResidentialUnit
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Capacity { get; set; }
        public int BedroomsNum { get; set; }
        public int BathroomsNum { get; set; }
        public int BedsNum { get; set; }
        public int LocationId { get; set; }
        public Location Location { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public int HostId { get; set; }
        public AppUser Host { get; set; }

        public ICollection<WishListItem> WishListItems { get; set; } = new List<WishListItem>();
        public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();

    }
}
