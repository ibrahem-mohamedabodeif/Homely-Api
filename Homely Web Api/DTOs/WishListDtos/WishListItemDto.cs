namespace Homely_Web_Api.DTOs.WishListDtos
{
    public class WishListItemDto
    {
        public int Id { get; set; }
        public int UnitId { get; set; }
        public string UnitTitle {get; set; }
        public string UnitSubtitle { get; set; }
        public string Location { get; set; }
        public string Category { get; set; }
    } 
}
