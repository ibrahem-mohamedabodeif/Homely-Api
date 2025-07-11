namespace Homely_Web_Api.DTOs.ReservationDtos
{
    public class UpdateReservationDto
    {
        public DateOnly? CheckIn { get; set; }
        public DateOnly? CheckOut { get; set; }
        public int? GuestsNum { get; set; }
        public double? IdentificationNumber { get; set; }
        public string? Notes { get; set; } = string.Empty;
        public string? Status { get; set; } = "Pending";
    }
}
