using Homely_Web_Api.Models.Residential_Units;
using Homely_Web_Api.Models;

namespace Homely_Web_Api.DTOs.ResidentialUnitDtos
{
    public class UnitDto
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
        public string Location { get; set; }
        public string Category { get; set; }

        public string Hostedby { get; set; }
    }
}
