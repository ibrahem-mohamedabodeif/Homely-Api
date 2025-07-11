namespace Homely_Web_Api.DTOs.ReservationDtos
{
    public class ReservationDto
    {
        public int Id { get; set; }
        public string UnitTitle { get; set; }
        public string Location { get; set; }
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
