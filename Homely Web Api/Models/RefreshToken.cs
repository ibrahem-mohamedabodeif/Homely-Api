namespace Homely_Web_Api.Models
{
    public class RefreshToken
    {
        public int Id { get; set; }
        public string Token { get; set; }
        public DateTime ExpiresAt { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? RevokedAt { get; set; } 

        public bool IsActive => ExpiresAt > DateTime.UtcNow && RevokedAt == null;
        public bool IsExpired => ExpiresAt <= DateTime.UtcNow;
        public bool IsRevoked => RevokedAt != null; 

        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}
