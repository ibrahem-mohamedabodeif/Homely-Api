namespace Homely_Web_Api.Models.Residential_Units
{
    public class Location
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public ICollection<ResidentialUnit> ResidentialUnits { get; set; } = new List<ResidentialUnit>();
    }
}
