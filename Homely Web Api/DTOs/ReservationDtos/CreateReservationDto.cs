namespace Homely_Web_Api.DTOs.ReservationDtos
{
    public class CreateReservationDto
    {
        public int UnitId { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public int GuestsNum { get; set; }
        public double IdentificationNumber { get; set; }
        public string? Notes { get; set; } = string.Empty;
    }
}
