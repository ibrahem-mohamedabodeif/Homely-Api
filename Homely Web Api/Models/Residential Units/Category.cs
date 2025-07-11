namespace Homely_Web_Api.Models.Residential_Units
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<ResidentialUnit> ResidentialUnits { get; set; } = new List<ResidentialUnit>();
    }
}
