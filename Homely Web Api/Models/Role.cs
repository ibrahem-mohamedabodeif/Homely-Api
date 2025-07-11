namespace Homely_Web_Api.Models
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<AppUserRole> AppUserRoles { get; set; } = new List<AppUserRole>();
    }
}
