using Homely_Web_Api.Models.Residential_Units;

namespace Homely_Web_Api.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public AppUser User { get; set; }
        public int UnitId { get; set; }
        public ResidentialUnit Unit { get; set; }
        public DateOnly CheckIn { get; set; }
        public DateOnly CheckOut { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public string Status { get; set; } = "Pending";
        public decimal TotalPrice { get; set; }
        public int GuestsNum { get; set; }
        public double IdentificationNumber { get; set; }
        public string? Notes { get; set; } = string.Empty;

    }
}
