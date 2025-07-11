﻿namespace Homely_Web_Api.DTOs.UserDTOs
{
    public class AuthResponseDto
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public DateTime TokenExpires { get; set; }
        public List<string> Roles { get; set; }
    }
}
