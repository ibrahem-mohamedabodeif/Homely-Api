namespace Homely_Web_Api.DTOs.ResidentialUnitDtos
{
    public class UpdateUnitDto
    {
        public string? Title { get; set; }
        public string? SubTitle { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public int? Capacity { get; set; }
        public int? BedroomsNum { get; set; }
        public int? BathroomsNum { get; set; }
        public int? BedsNum { get; set; }
        public string? Category { get; set; }

        public string? Address { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Country { get; set; }
    }
}
